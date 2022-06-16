using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void AgregarCliente_CuandoYaExisteUnClienteConElMismoDni_DeberiaRetornarFalse()
        {
            // Arrange
            Libreria libreria = new Libreria();
            Cliente clienteUno = new Cliente("Francisco", "Rodriguez", 40234543, 1134225676, "franrg@gmail.com");
            Cliente clienteDos = new Cliente("John", "Ramson", 40234543, 1145872673, "john12ram@gmail.com");

            // Act
            libreria.ListaClientes.Add(clienteUno);

            bool clienteAgregadoConExito = libreria + clienteDos;

            // Assert
            Assert.IsFalse(clienteAgregadoConExito);
        }

        [TestMethod]
        public void LibroExistente_CuandoDosLibrosTienenElMismoCodigo_DeberiaRetornarTrue()
        {
            // Arrange
            Libreria libreria = new Libreria();
            Libro libroUno = new Libro("La metamorfosis", "Franz Kafka", EGenero.Ficcion, 176, 1234, 1500);
            Libro libroDos = new Libro("Los demonios", "Fiódor Dostoyevski", EGenero.Ficcion, 912, 1234, 3800);

            // Act
            libreria.ListaLibros.Add(libroUno);
            bool libroYaExiste = libreria == libroDos;

            // Assert
            Assert.IsTrue(libroYaExiste);
        }
    }
}

