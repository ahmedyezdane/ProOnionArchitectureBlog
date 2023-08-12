using Dapper;
using System.Data;

namespace Data.Contracts;

public interface IDapperService : IService
{
    Task<int> ExecuteAsync(string query, CancellationToken ct, DynamicParameters parameters = null, CommandType type = CommandType.StoredProcedure);
    Task<IEnumerable<T>> QueryAsync<T>(T outputType,string query, CancellationToken ct, DynamicParameters parameters = null, CommandType type = CommandType.Text);    
    Task<SqlMapper.GridReader> QueryMultipleAsync(string query, CancellationToken ct, DynamicParameters parameters = null, CommandType type = CommandType.Text);
}
