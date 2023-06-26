using backend_proyecto_final_gpds.Connection;
using backend_proyecto_final_gpds.Dominio;
using Dapper;
using System.Data;


namespace backend_proyecto_final_gpds.Servicios
{
    public static class LibroServicios
    {
        public static IEnumerable<Libro> Get()
        {
            const string sql = "SELECT * FROM LIBRO WHERE ESTADO_REGISTRO = 1";
            return DBManager.Instance.GetData<Libro>(sql);
        }

        public static T GetById<T>(int id) where T : Libro
        {
            const string sql = "SELECT * FROM LIBRO WHERE ID = @Id AND ESTADO_REGISTRO = 1";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.GetDataConParametros<T>(sql, parameters);
            return result.FirstOrDefault();

        }

        public static int Insert(Libro libro)
        {
            const string sql = "INSERT INTO LIBRO([TITULO], [AUTOR], [ANIO]) VALUES (@Titulo, @Autor, @Anio)";
            var parameters = new DynamicParameters();
            parameters.Add("Titulo", libro.Titulo, DbType.String);
            parameters.Add("Autor", libro.Autor, DbType.String);
            parameters.Add("Anio", libro.Anio, DbType.String);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        public static int Update(Libro libro)
        {
            const string sql = "UPDATE [LIBRO] SET TITULO = @Titulo, AUTOR = @Autor, ANIO = @Anio WHERE ID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", libro.Id, DbType.Int64);
            parameters.Add("Titulo", libro.Titulo, DbType.String);
            parameters.Add("Autor", libro.Autor, DbType.String);
            parameters.Add("Anio", libro.Anio, DbType.String);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        public static int Delete(int id)
        {
            const string sql = "UPDATE [LIBRO] SET ESTADO_REGISTRO = 0 WHERE ID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        public static int Recover(int id)
        {
            const string sql = "UPDATE [LIBRO] SET ESTADO_REGISTRO = 1 WHERE ID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

    }
}
