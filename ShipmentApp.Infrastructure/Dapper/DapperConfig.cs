using System.Data;

using Dapper;

using DataLayer.Dapper;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ShipmentApp.Infrastructure.Dapper
{
    public class DapperConfig : IDapperConfig
    {
        public IConfiguration Configuration { get; }
        public string Con { get; set; }

        public DapperConfig(IConfiguration configuration)
        {
            Configuration = configuration;
            Con = Configuration.GetConnectionString("ShipmentDB");
        }

        public List<T> Query<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return db.Query<T>(query, parameter, null, true, null, commandType).ToList();
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (var conn = new SqlConnection(Con))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T QueryFirst<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return db.QueryFirst<T>(query, parameter, null, null, commandType);
            }
        }

        public async Task<T> QueryFirstAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return await db.QueryFirstAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T QueryFirstOrDefault<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return db.QueryFirstOrDefault<T>(query, parameter, null, null, commandType);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (var conn = new SqlConnection(Con))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T QuerySingle<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return db.QuerySingle<T>(query, parameter, null, null, commandType);
            }
        }

        public async Task<T> QuerySingleAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return await db.QuerySingleAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T QuerySingleOrDefault<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return db.QuerySingleOrDefault<T>(query, parameter, null, null, commandType);
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return await db.QuerySingleOrDefaultAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T ExecuteScalar<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : IConvertible
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return db.ExecuteScalar<T>(query, parameter, null, null, commandType);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : IConvertible
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return await db.ExecuteScalarAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public int ExecuteQuery(string query, object parameter = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return db.Execute(query, parameter, null, null, commandType);
            }
        }

        public async Task<int> ExecuteQueryAsync(string query, object parameter = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection db = new SqlConnection(Con))
            {
                return await db.ExecuteAsync(query, parameter, null, null, commandType);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SqlHelper() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
