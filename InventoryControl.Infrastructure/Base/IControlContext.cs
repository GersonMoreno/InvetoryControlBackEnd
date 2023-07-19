using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControl.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.Infrastructure.Base
{
    public class IControlContext: DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public IControlContext(DbContextOptions<IControlContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Articulos
            modelBuilder.Entity<Articulo>().HasKey(x => x.Id);
            //Cajas
            modelBuilder.Entity<Caja>().HasKey(x => x.Id);
            modelBuilder.Entity<Caja>().HasOne(x => x.Usuario);

            //Facturas
            modelBuilder.Entity<Factura>().HasKey(x => x.Id);
            modelBuilder.Entity<Factura>().HasOne(x => x.Usuario);
            modelBuilder.Entity<Factura>().HasMany(x => x.Articulos);

            //Compras
            modelBuilder.Entity<Compra>().HasOne(x => x.Proveedor);

            //Venta
            modelBuilder.Entity<Venta>().HasOne(x => x.Cliente);

            //Persona
            modelBuilder.Entity<Persona>().HasKey(x => x.Id);
            //Gastos
            modelBuilder.Entity<Gasto>().HasKey(x => x.Id);
            modelBuilder.Entity<Gasto>().HasOne(x => x.Persona);

            //Proveedor
            modelBuilder.Entity<Proveedor>().HasKey(x => x.Id);
            //Usuario
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
            modelBuilder.Entity<Usuario>().HasOne(x => x.Persona);
            


        }
    }
}
