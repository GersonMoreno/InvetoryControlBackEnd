using InventoryControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Articulo:Entity
    {
        public string? Descripcion { get; private set; }
        public int Cantidad { get; private set; }
        public decimal Costo { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Utilidad { get; private set; }
        public bool Habilitado { get; private set; }
        public Articulo(ArticuloDTO articuloDTO)
        {
            Descripcion = articuloDTO.Descripcion;
            Cantidad = articuloDTO.Cantidad;
            Costo = articuloDTO.Costo;
            Precio = articuloDTO.Precio;
            Habilitado = true;
            CalcularUtilidad();
        }
        public Articulo()
        {
            
        }
        private void CalcularUtilidad()
        {
            Utilidad = Precio - Costo;
        }
        public void Deshabilitar()
        {
            Habilitado = false;
        }
        public void RestarStock(int cantidad)
        {
            Cantidad -= cantidad;
        }

    }
    public class ArticuloDTO
    {
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
    }
}
