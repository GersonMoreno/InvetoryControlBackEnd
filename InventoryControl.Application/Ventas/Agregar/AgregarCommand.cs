using InventoryControl.Application.Shared;
using InventoryControl.Application.Ventas.Consultar;
using InventoryControl.Domain;
using InventoryControl.Domain.Base;
using InventoryControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Application.Ventas.Agregar
{
    public class AgregarCommand
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public AgregarCommand(IUnitOfWork UnitOfWork,IAuthenticationService authenticationService)
        {
            _UnitOfWork = UnitOfWork;
            _authenticationService = authenticationService;
        }

        public async Task<BaseResponse<bool>> Handle(AgregarRequest request)
        {
            await _UnitOfWork.BeginTransaction();
            var Errores = new List<string>();
            if(request is null) return new BaseResponse<bool>(new List<string>() { "La venta a realizar no pude ser nula." });

            if (request.Articulos is null || !request.Articulos.Any()) Errores.Add("Los articulos a facturar no pueden ser nulos.");

            if (request.Descuento is null || request.Descuento < 0) Errores.Add("El descuento no pude ser nulo o negativo.");

            if (Errores.Any()) return new BaseResponse<bool>(Errores);
            else
            {
                try
                {
                    var articulos = new List<Articulo>();
                    request.Articulos.ForEach(x =>
                    {
                        var articulo = _UnitOfWork.GenericRepository<Articulo>().Find(x.ArticuloId);
                        if (articulo is null) throw new Exception("Hay articulos que no existen en el inventario");
                        articulos.Add(articulo);
                    });

                    var usuarioId = _authenticationService.GetIdUser();
                    if (usuarioId == 0) return new BaseResponse<bool>(new List<string>() { "El usuario vendedor no esta autenticado." });

                    var usuario = _UnitOfWork.GenericRepository<Usuario>().Find(usuarioId);
                    if (usuario is null)
                        return new BaseResponse<bool>(new List<string>() { "El usuario vendedor no existe en la base de datos." });

                    if (!usuario.Habilitado)
                        return new BaseResponse<bool>(new List<string>() { $"El usuario {usuario.NombreUsuario} no se encuentra habilidado." });

                    var caja = _UnitOfWork.GenericRepository<Caja>().FindBy(x => x.Usuario.Id == usuario.Id && x.Estado == EstadoCaja.Abierta).FirstOrDefault();
                    
                    var facuraDTO = MapFacturaDTO(usuario,DateTime.Now);

                    var cliente = _UnitOfWork.GenericRepository<Persona>().Find(request.clienteId);

                    var ventaDTO = MapVentaDTO(cliente, request.Descuento);

                    var venta = new Venta(facuraDTO, ventaDTO, caja);

                    request.Articulos.ForEach(x =>
                    {
                        var articulo = articulos.Find(art => art.Id == x.ArticuloId);
                        venta.FacturarArticulo(ref articulo, x.Cantidad);
                        _UnitOfWork.GenericRepository<Articulo>().Update(articulo);
                    });

                    var response = venta.RealizarVenta();
                    if (response.HuboError) Errores.Add(response.Mensaje);

                    if (Errores.Any())
                    {
                        await _UnitOfWork.Rollback();

                        return new BaseResponse<bool>(Errores);
                    }

                    await _UnitOfWork.Commit();
                    return new BaseResponse<bool>(response.Mensaje);

                }
                catch (Exception ex)
                {
                    Errores.Add(ex.Message);
                    await _UnitOfWork.Rollback();
                    return new BaseResponse<bool>(Errores);
                }
            }
        }
        private FacturaDTO MapFacturaDTO(Usuario usuario, DateTime fecha)
        {
            return new FacturaDTO() { Usuario = usuario, Fecha = fecha };
        }
        private VentaDTO MapVentaDTO(Persona cliente, decimal? descuento)
        {
            return new VentaDTO() { Cliente = cliente, Descuento = descuento };
        }

    }
}
