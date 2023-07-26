using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain.Test.Utilidades
{
    public class ObjetosArticulo
    {
        public Articulo SinStock()
        {
            var articuloDto = new ArticuloDTO();
            articuloDto.Cantidad = 0;
            articuloDto.Descripcion = "Sueter";
            return new Articulo(articuloDto);
        }
        public Articulo Deshabilitdo()
        {
            var articuloDto = new ArticuloDTO();
            articuloDto.Cantidad = 100;
            articuloDto.Descripcion = "Sueter";

            var articulo = new Articulo(articuloDto);
            articulo.Deshabilitar();
            return articulo;
        }
        public Articulo Exitoso()
        {
            var articuloDto = new ArticuloDTO();
            articuloDto.Descripcion = "Sueter";
            articuloDto.Cantidad = 100;
            articuloDto.Costo = 5000;
            articuloDto.Precio = 7000;
            var articulo = new Articulo(articuloDto);
            articulo.AsignarId();
            return articulo;
        }
    }
}
