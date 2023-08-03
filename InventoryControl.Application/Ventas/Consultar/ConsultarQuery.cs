using InventoryControl.Application.Shared;
using InventoryControl.Domain;
using InventoryControl.Domain.Base;
using InventoryControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Application.Ventas.Consultar
{
    public class ConsultarQuery
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public ConsultarQuery(IUnitOfWork UnitOfWork, IAuthenticationService authenticationService)
        {
            _UnitOfWork = UnitOfWork;
            _authenticationService = authenticationService;
        }
        public Task<BaseResponse<List<ConsultarResponse>>> Handle()
        {
            try
            {
                var usuarioId = _authenticationService.GetIdUser();
                if (usuarioId == 0) return Task.FromResult(new BaseResponse<List<ConsultarResponse>>(
                    new List<string>() { "El usuario vendedor no esta autenticado."})
                    );
                var usuario = _UnitOfWork.GenericRepository<Usuario>().Find(usuarioId);
                if(usuario is null)
                    return Task.FromResult(new BaseResponse<List<ConsultarResponse>>(
                    new List<string>() { "El usuario vendedor no existe en la base de datos." })
                    );
                if(!usuario.Habilitado)
                    return Task.FromResult(new BaseResponse<List<ConsultarResponse>>(
                    new List<string>() { $"El usuario {usuario.NombreUsuario} no se encuentra habilidado." })
                    );
             
                var caja = _UnitOfWork.GenericRepository<Caja>().FindBy(x => x.Usuario.Id == usuario.Id
                && x.Estado == EstadoCaja.Abierta)?.FirstOrDefault();

                var lista = new List<ConsultarResponse>();
                if(caja is not null)
                {
                    var ventas = _UnitOfWork.GenericRepository<Venta>().FindBy(x => x.Caja.Id == caja.Id,
                    includeProperties: "Cliente")?.ToList();
                    if (ventas is not null)
                    {
                        lista = ventas.Select(x => MapConsultarResponse(x)).ToList();
                    }
                }
                return Task.FromResult(new BaseResponse<List<ConsultarResponse>>("Se consultó exitosomente.", lista));

            }
            catch (Exception ex)
            {

                return Task.FromResult(new BaseResponse<List<ConsultarResponse>>(
                    new List<string>() { $"Error: {ex.Message}" })
                    );
            }
            


        }
        private ConsultarResponse MapConsultarResponse(Venta venta)
        {
            var response = new ConsultarResponse();
            response.VentaId = venta.Id;
            response.Subtotal = venta.Subtotal;
            response.Descuento = venta.Descuento;
            response.Total = venta.Total;
            response.Fecha = venta.Fecha;
            response.NumeroIdentificacion = venta.Cliente.NumeroIdentificacion;
            response.NombreCompleto = venta.Cliente.NombreCompleto;
            return response;
        }
    }
}
