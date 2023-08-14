
using Dapper;
using Data;
using Data.Contracts;
using System.Data;

namespace Services.DataServices;
public class DapperService : IDapperService
{
    private readonly DapperUtility _dapperUtility;

    public DapperService(DapperUtility dapperUtility)
    {
        _dapperUtility = dapperUtility;
    }

    public async Task<int> ExecuteAsync(string query, CancellationToken ct, DynamicParameters parameters = null, CommandType type = CommandType.StoredProcedure)
    {
        using (var db = _dapperUtility.GetConnection())
        {
            var result = await db.ExecuteAsync(new CommandDefinition(query, parameters, commandType: type, cancellationToken: ct));
            return result;
        }
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(T outputType, string query, CancellationToken ct, DynamicParameters parameters = null, CommandType type = CommandType.Text)
    {
        using(var db = _dapperUtility.GetConnection())
        {
            var result = await db.QueryAsync<T>(new CommandDefinition(query,parameters,commandType: type,cancellationToken:ct));
            return result.ToList();
        }
    }

    public async Task<SqlMapper.GridReader> QueryMultipleAsync(string query, CancellationToken ct, DynamicParameters parameters = null, CommandType type = CommandType.Text)
    {
        using (var db = _dapperUtility.GetConnection())
        {
            var result = await db.QueryMultipleAsync(new CommandDefinition(query, parameters, commandType: type, cancellationToken: ct));
            return result;
        }
    }
}
