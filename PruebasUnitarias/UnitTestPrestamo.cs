using backend_proyecto_final_gpds.Connection;
using backend_proyecto_final_gpds.Dominio;
using backend_proyecto_final_gpds.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestPrestamo
    {
        public UnitTestPrestamo()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=db_biblioteca_pruebas_unit.mssql.somee.com;packet size=4096;user id=gonzalesal_SQLLogin_1;pwd=52cgeyk4sh;data source=db_biblioteca_pruebas_unit.mssql.somee.com;persist security info=False;initial catalog=db_biblioteca_pruebas_unit";
        }

        [Fact, TestPriority(0)]
        public void B_Prestamo_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar Métodos
            var result = PrestamoServicios.Get();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void C_Prestamo_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = PrestamoServicios.GetById(3);
            Assert.Equal(result.Id, result.Id);
        }

        [Fact, TestPriority(2)]
        public void A_Prestamo_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Prestamo prestamo = new();
            prestamo.IdUsuario = 1;
            prestamo.IdLibro = 2;
            prestamo.FechaRetiro = "23-06-2023";
            prestamo.FechaDevolucion = "26-06-2023";

            // Act
            var result = PrestamoServicios.Insert(prestamo);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void D_Prestamo_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Prestamo prestamo = new();
            prestamo.Id = 4;
            prestamo.IdUsuario = 2;
            prestamo.IdLibro = 3;
            prestamo.FechaRetiro = "23-06-2024";
            prestamo.FechaDevolucion = "26-06-2024";

            var result = PrestamoServicios.Update(prestamo);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(4)]
        public void E_Prestamo_Delete_RetornaUno()
        {
            Console.WriteLine("TestPriority(4)");
            var result = PrestamoServicios.Delete(3);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(5)]
        public void F_Prestamo_Recover_RetornaUno()
        {
            Console.WriteLine("TestPriority(5)");
            var result = PrestamoServicios.Recover(3);

            Assert.Equal(1, result);
        }
    }
}