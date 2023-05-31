using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class UserLog
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserLog(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }

        public bool Login(User log)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", log.Username);
                command.Parameters.AddWithValue("@Password", log.Password);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}