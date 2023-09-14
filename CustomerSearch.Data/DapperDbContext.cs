using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CustomerSearch.Data;

public class DapperDbContext
{
    private readonly IConfiguration Configuration;
    private readonly string? connectionString;
    public DapperDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
        connectionString = Configuration.GetConnectionString("CustomerConnection");
    }

    public IDbConnection CreateConnection() => new SqlConnection(connectionString);
}
