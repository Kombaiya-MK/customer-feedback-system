using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace CustomerFeedbackSystem.Infrastructure.Context
{
    [ExcludeFromCodeCoverage]
    public class FeedbackContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public FeedbackContext()
        {
            
        }
        public FeedbackContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }

        public virtual IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
