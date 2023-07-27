namespace InventoryControl.Domain.Test
{
    using Domain;
    using InventoryControl.Domain.Test.Utilidades;
    public class VentaTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConFacuraNula()
        {
            try
            {
                var venta = new ObjetosVenta().ConFacturaNula();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("La factura no puede ser nula."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConCajaNula()
        {
            try
            {
                var venta = new ObjetosVenta().ConCajaNula();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("La caja debe estar abierta."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConCajaVacia()
        {
            try
            {
                var venta = new ObjetosVenta().ConCajaVacia();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("La caja debe estar abierta."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConCajaCerrada()
        {
            try
            {
                var venta = new ObjetosVenta().ConCajaCerrada();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("La caja debe estar abierta."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConVendedorNulo()
        {
            try
            {
                var venta = new ObjetosVenta().SinUsuario();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("El usuario no puede ser nulo o vacío."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConUsuarioVacio()
        {
            try
            {
                var venta = new ObjetosVenta().ConUsuarioVacio();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("El usuario no puede ser nulo o vacío."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConFechaNula()
        {
            try
            {
                var venta = new ObjetosVenta().ConFechaNula();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("La fecha no puede ser nulo."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaNula()
        {
            try
            {
                var venta = new ObjetosVenta().ConVentaNula();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("La venta no puede ser nula."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConClienteNulo()
        {
            try
            {
                var venta = new ObjetosVenta().ConClienteNulo();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("El cliente no puede ser nula o vacío."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConClienteVacio()
        {
            try
            {
                var venta = new ObjetosVenta().ConClienteVacio();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("El cliente no puede ser nula o vacío."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConDescuentoNulo()
        {
            try
            {
                var venta = new ObjetosVenta().ConDescuentoNulo();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("El descuento no puede ser nulo o menor que 0."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConDescuentoMenor0()
        {
            try
            {
                var venta = new ObjetosVenta().ConDescuentoMenor0();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("El descuento no puede ser nulo o menor que 0."));
            }
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConArticulosSinStock()
        {
            var venta = new ObjetosVenta().Exitosa();
            var articulo = new ObjetosArticulo().SinStock();

            var response = venta.FacturarArticulo(ref articulo,3);

            Assert.IsTrue(response.HuboError);
            Assert.That(response.Mensaje, Is.EqualTo("El articulo Sueter no tiene stock, por favor revisar."));
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConArticulosDeshabilitados()
        {
            var venta = new ObjetosVenta().Exitosa();
            var articulo = new ObjetosArticulo().Deshabilitdo();

            var response = venta.FacturarArticulo(ref articulo, 3);

            Assert.IsTrue(response.HuboError);
            Assert.That(response.Mensaje, Is.EqualTo("El articulo Sueter esta deshabilitado, por favor revisar."));
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConCantidadVenderMenor1()
        {
            var venta = new ObjetosVenta().Exitosa();
            var articulo = new ObjetosArticulo().Exitoso();

            var response = venta.FacturarArticulo(ref articulo, 0);

            Assert.IsTrue(response.HuboError);
            Assert.That(response.Mensaje, Is.EqualTo("La cantidad a vender del articulo Sueter debe ser mayor a 0."));
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConCantidadVenderMayorAlStock()
        {
            var venta = new ObjetosVenta().Exitosa();
            var articulo = new ObjetosArticulo().Exitoso();

            var response = venta.FacturarArticulo(ref articulo, 101);

            Assert.IsTrue(response.HuboError);
            Assert.That(response.Mensaje, Is.EqualTo("La cantidad a vender del articulo Sueter no puede ser mayor a la cantidad en stock."));
        }
        [Test]
        public void SePuedeAgregarUnArticuloFactura()
        {
            var venta = new ObjetosVenta().Exitosa();
            var articulo = new ObjetosArticulo().Exitoso();

            var response = venta.FacturarArticulo(ref articulo, 1);

            Assert.IsFalse(response.HuboError);
            Assert.That(articulo.Cantidad, Is.EqualTo(99));
            Assert.That(venta.DetallesFactura, Has.Count.EqualTo(1));
            Assert.That(venta.Subtotal, Is.EqualTo(7000));
            Assert.That(response.Mensaje, Is.EqualTo("Se facturó con éxito el articulo."));
        }
        [Test]
        public void NoSePuedeHacerUnaVentaSinTenerDetelleVenta()
        {
            var venta = new ObjetosVenta().ConDescuentode4000();

            var response = venta.RealizarVenta();

            Assert.IsTrue(response.HuboError);
            Assert.That(response.Mensaje, Is.EqualTo("No se puede realizar una venta sin articulos facturados."));
        }
        [Test]
        public void NoSePuedeHacerUnaVentaConTotalMenorSumaUtilidades()
        {
            var venta = new ObjetosVenta().ConDescuentode4000();
            var articulo = new ObjetosArticulo().Exitoso();

            var responseArticulo = venta.FacturarArticulo(ref articulo, 1);

            Assert.IsFalse(responseArticulo.HuboError);
            Assert.That(articulo.Cantidad, Is.EqualTo(99));
            Assert.That(venta.DetallesFactura, Has.Count.EqualTo(1));

            var response = venta.RealizarVenta();

            Assert.IsTrue(response.HuboError);
            Assert.That(response.Mensaje, Is.EqualTo("No se puede hacer descuento 4000, porque es mayor a las utilidades de la venta."));
        }
        [Test]
        public void SePuedeRelizarVentaExitosamente()
        {
            var venta = new ObjetosVenta().Exitosa();
            var articulo = new ObjetosArticulo().Exitoso();

            var responseArticulo = venta.FacturarArticulo(ref articulo, 1);

            Assert.IsFalse(responseArticulo.HuboError);
            Assert.That(articulo.Cantidad, Is.EqualTo(99));
            Assert.That(venta.DetallesFactura, Has.Count.EqualTo(1));

            var response = venta.RealizarVenta();

            Assert.IsFalse(response.HuboError);
            Assert.That(response.Mensaje, Is.EqualTo("Se realizó la venta correctamente."));
        }
    }
}
