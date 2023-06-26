using backend_proyecto_final_gpds.Connection;
using backend_proyecto_final_gpds.Dominio;
using Dapper;
using System.Data;


namespace backend_proyecto_final_gpds.Servicios
{
    public static class UsuarioServicios
    {
        public static IEnumerable<Usuario> Get()
        {
            const string sql = "SELECT * FROM USUARIO WHERE ESTADO_REGISTRO = 1";
            return DBManager.Instance.GetData<Usuario>(sql);
        }

        public static T GetById<T>(int id) where T : Usuario
        {
            const string sql = "SELECT * FROM USUARIO WHERE ID = @Id AND ESTADO_REGISTRO = 1";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<T>(sql, parameters);

            return result.FirstOrDefault();

        }

        public static int Insert(Usuario usuario)
        {
            const string sql = "INSERT INTO USUARIO([NOMBRE_COMPLETO], [CARNET], [CORREO], [CELULAR]) VALUES (@NombreCompleto, @Carnet, @Correo, @Celular) ";
            var parameters = new DynamicParameters();
            parameters.Add("NombreCompleto", usuario.NombreCompleto, DbType.String);
            parameters.Add("Carnet", usuario.Carnet, DbType.String);
            parameters.Add("Correo", usuario.Correo, DbType.String);
            parameters.Add("Celular", usuario.Celular, DbType.String);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        public static int Update(Usuario usuario)
        {
            const string sql = "UPDATE [USUARIO] SET NOMBRE_COMPLETO = @NombreCompleto, CARNET = @Carnet, CORREO = @Correo, CELULAR = @Celular WHERE ID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", usuario.Id, DbType.Int64);
            parameters.Add("NombreCompleto", usuario.NombreCompleto, DbType.String);
            parameters.Add("Carnet", usuario.Carnet, DbType.String);
            parameters.Add("Correo", usuario.Correo, DbType.String);
            parameters.Add("Celular", usuario.Celular, DbType.String);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        public static int Delete(int id)
        {
            const string sql = "UPDATE [USUARIO] SET ESTADO_REGISTRO = 0 WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        public static int Recover(int id)
        {
            const string sql = "UPDATE [USUARIO] SET ESTADO_REGISTRO = 1 WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

    }
}
