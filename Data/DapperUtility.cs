using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data;

public class DapperUtility
{
    private IConfiguration configuration;
    public DapperUtility(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(configuration.GetConnectionString("SqlConnection"));
    }
}
