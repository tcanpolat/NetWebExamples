using Microsoft.Data.SqlClient;
using System.Data;

namespace _19_DapperExample.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // veritabanı bağlantısını oluşturan method
        // bu method _connectionString i kullanarak yeni bir SqlConnection nesnesi oluşturur ve döndürü.

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
