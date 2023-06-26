using Dapper;
using System.Data.SqlClient;

namespace backend_proyecto_final_gpds.Connection
{
    public class DBManager
    {
        #region Fields
        private static readonly object lockObj = new();
        private static DBManager? instance;
        #endregion Fields

        #region Constructors
        private DBManager() { }
        #endregion Constructors

        #region Methods
        public static DBManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new DBManager();
                    }
                }
                return instance;
            }
        }
        public string? ConnectionString { get; set; }

        public IEnumerable<T> GetData<T>(string sql)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return connection.Query<T>(sql);
        }

        public IEnumerable<T> GetDataConParametros<T>(string sql, DynamicParameters dynamicParameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return connection.Query<T>(sql, dynamicParameters);
        }

        public int SetData(string sql, DynamicParameters dynamicParameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return connection.Execute(sql, dynamicParameters);
        }
        #endregion Methods
    }
}
