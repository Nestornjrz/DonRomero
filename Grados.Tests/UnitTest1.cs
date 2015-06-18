using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grados.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PasoPorValor()
        {
            LibroDeCalificaciones libro = new LibroDeCalificaciones();

            libro.Nombre = "Nombre no asignado";
            AsignarNombre(libro);
            Assert.AreEqual("Nombre no asignado", libro.Nombre);
        }
        private void AsignarNombre(LibroDeCalificaciones libro)
        {
            libro.Nombre = "Nombre Asignado";
        }
       
    }
}
