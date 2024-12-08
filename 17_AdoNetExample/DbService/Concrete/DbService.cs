using _17_AdoNetExample.DbService.Abstract;
using _17_AdoNetExample.Models;
using Microsoft.Data.SqlClient;

namespace _17_AdoNetExample.DbService.Concrete
{
    public class DbService : IDbService
    {
        private readonly string _connectionString;

        public DbService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void ExecuteNonQuery(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query,connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Eğer sorgunuz INSERT,UPDATE,DELETE işlemleri içeriyorsa kullanılır. Geriye int deger döndürür.

        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if(parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Eğer sorgunuz geriye bir tablo döndürüyorsa kullanılır. (SELECT * FROM Students)
        public List<Student> ExecuteReader(string query)
        {
            var result = new List<Student>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) {
                            var model = new Student()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Age = Convert.ToInt32(reader["Age"])
                            };

                            result.Add(model);
                        
                        }
                    }

                   
                }
            }
            return result;
        }

        // Eğer sorgunuz geriye tek bir değer döndürüyorsa kullanılır. Aggregate function (select count(*) from Students)
        public object ExecuteScalar(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }
    }
}
