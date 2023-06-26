using backend_proyecto_final_gpds.Connection;
using backend_proyecto_final_gpds.Dominio;
using backend_proyecto_final_gpds.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestLibro
    {
        public UnitTestLibro()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=db_biblioteca_pruebas_unit.mssql.somee.com;packet size=4096;user id=gonzalesal_SQLLogin_1;pwd=52cgeyk4sh;data source=db_biblioteca_pruebas_unit.mssql.somee.com;persist security info=False;initial catalog=db_biblioteca_pruebas_unit";
        }

        [Fact, TestPriority(0)]
        public void B_Libro_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar Métodos
            var result = LibroServicios.Get();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void C_Libro_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = LibroServicios.GetById<Libro>(11);
            Assert.Equal(result.Id, result.Id);
        }

        [Fact, TestPriority(2)]
        public void A_Libro_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Libro libro = new();
            libro.Titulo = "Titulo UnitTest";
            libro.Autor = "Autor UnitTest";
            libro.Anio = "AnioU";

            // Act
            var result = LibroServicios.Insert(libro);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void D_Libro_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Libro libro = new();
            libro.Id = 11;
            libro.Titulo = "Titulo UnitTest Update";
            libro.Autor = "Autor UnitTest Update";
            libro.Anio = "AnioD";

            var result = LibroServicios.Update(libro);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(4)]
        public void E_Libro_Delete_RetornaUno()
        {
            Console.WriteLine("TestPriority(4)");
            var result = LibroServicios.Delete(11);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(5)]
        public void F_Libro_Recover_RetornaUno()
        {
            Console.WriteLine("TestPriority(5)");
            var result = LibroServicios.Recover(10);

            Assert.Equal(1, result);
        }
    }
}