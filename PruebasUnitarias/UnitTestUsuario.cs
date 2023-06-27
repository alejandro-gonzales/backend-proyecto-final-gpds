using backend_proyecto_final_gpds.Connection;
using backend_proyecto_final_gpds.Dominio;
using backend_proyecto_final_gpds.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestUsuario
    {
        public UnitTestUsuario()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=db_biblioteca_pruebas_unit.mssql.somee.com;packet size=4096;user id=gonzalesal_SQLLogin_1;pwd=52cgeyk4sh;data source=db_biblioteca_pruebas_unit.mssql.somee.com;persist security info=False;initial catalog=db_biblioteca_pruebas_unit";
        }

        [Fact, TestPriority(0)]
        public void B_Usuario_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar Métodos
            var result = UsuarioServicios.Get();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void C_Usuario_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = UsuarioServicios.GetById<Usuario>(3);
            Assert.Equal(result.Id, result.Id);
        }

        [Fact, TestPriority(2)]
        public void A_Usuario_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Usuario usuario = new();
            usuario.NombreCompleto = "Usuario UnitTest";
            usuario.Carnet = "CarnetTest";
            usuario.Correo = "Correo UnitTest";
            usuario.Celular = "Celular UnitTest";

            // Act
            var result = UsuarioServicios.Insert(usuario);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void D_Usuario_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Usuario usuario = new();
            usuario.Id = 17;
            usuario.NombreCompleto = "Usuario UnitTest Update";
            usuario.Carnet = "CarnetUpda";
            usuario.Correo = "Correo UnitTest Update";
            usuario.Celular = "Celular UnitTest Update";

            var result = UsuarioServicios.Update(usuario);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(4)]
        public void E_Usuario_Delete_RetornaUno()
        {
            Console.WriteLine("TestPriority(4)");
            var result = UsuarioServicios.Delete(17);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(5)]
        public void F_Usuario_Recover_RetornaUno()
        {
            Console.WriteLine("TestPriority(5)");
            var result = UsuarioServicios.Recover(17);

            Assert.Equal(1, result);
        }
    }
}