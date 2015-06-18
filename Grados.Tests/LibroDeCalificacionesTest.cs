using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grados;

namespace Grados.Tests
{
    [TestClass]
    public class LibroDeCalificacionesTest
    {
        [TestMethod]
        public void CalcularNotaMasAlta()
        {
            LibroDeCalificaciones libro = new LibroDeCalificaciones();
            libro.AddCalificacion(90f);
            libro.AddCalificacion(50f);

            Estadisticas est = libro.GenerarEstadistica();
            Assert.AreEqual(90f, est.NotaMasAlta);
        }
    }
}
