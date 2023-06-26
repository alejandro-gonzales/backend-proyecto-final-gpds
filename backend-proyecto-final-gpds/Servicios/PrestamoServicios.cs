using backend_proyecto_final_gpds.Connection;
using backend_proyecto_final_gpds.Dominio;
using Dapper;
using System.Data;


namespace backend_proyecto_final_gpds.Servicios
{
    public static class PrestamoServicios
    {
        public static IEnumerable<Prestamo> Get()
        {
            const string sql = "SELECT * FROM PRESTAMO WHERE ESTADO_REGISTRO = 1";
            var enummerablePrestamo = DBManager.Instance.GetData<Prestamo>(sql);
            foreach (var item in enummerablePrestamo)
            {
                item.Usuario = UsuarioServicios.GetById<Usuario>(item.IdUsuario);
                item.Libro = LibroServicios.GetById<Libro>(item.IdLibro);
            }
            return enummerablePrestamo;
        }

        public static Prestamo GetById(int id)
        {
            const string sql = "SELECT * FROM PRESTAMO WHERE ID = @Id AND ESTADO_REGISTRO = 1";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.GetDataConParametros<Prestamo>(sql, parameters);
            Prestamo prestamo = result.FirstOrDefault();
            if (prestamo != null)
            {
                prestamo.Usuario = UsuarioServicios.GetById<Usuario>(prestamo.IdUsuario);
                prestamo.Libro = LibroServicios.GetById<Libro>(prestamo.IdLibro);
            }
            return result.FirstOrDefault();
        }

        public static int Insert(Prestamo prestamo)
        {
            const string sql = "INSERT INTO PRESTAMO([ID_USUARIO], [ID_LIBRO], [FECHA_RETIRO], [FECHA_DEVOLUCION]) VALUES (@IdUsuario, @IdLibro, @FechaRetiro, @FechaDevolucion) ";
            var parameters = new DynamicParameters();
            parameters.Add("IdUsuario", prestamo.IdUsuario, DbType.Int64);
            parameters.Add("IdLibro", prestamo.IdLibro, DbType.Int64);
            parameters.Add("FechaRetiro", prestamo.FechaRetiro, DbType.Date);
            parameters.Add("FechaDevolucion", prestamo.FechaDevolucion, DbType.Date);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        public static int Update(Prestamo prestamo)
        {
            const string sql = "UPDATE [PRESTAMO] SET ID_USUARIO = @IdUsuario, ID_LIBRO = @IdLibro, FECHA_RETIRO = @FechaRetiro, FECHA_DEVOLUCION = @FechaDevolucion WHERE ID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", prestamo.Id, DbType.Int64);
            parameters.Add("IdUsuario", prestamo.IdUsuario, DbType.Int64);
            parameters.Add("IdLibro", prestamo.IdLibro, DbType.Int64);
            parameters.Add("FechaRetiro", prestamo.FechaRetiro, DbType.Date);
            parameters.Add("FechaDevolucion", prestamo.FechaDevolucion, DbType.Date);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        public static int Delete(int id)
        {
            const string sql = "UPDATE [PRESTAMO] SET ESTADO_REGISTRO = 0 WHERE ID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        public static int Recover(int id)
        {
            const string sql = "UPDATE [PRESTAMO] SET ESTADO_REGISTRO = 1 WHERE ID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);
            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }
    }
}
