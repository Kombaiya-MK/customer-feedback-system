using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CustomerFeedbackSystem.Infrastructure.Context
{
    public class FeedbackContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public FeedbackContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
