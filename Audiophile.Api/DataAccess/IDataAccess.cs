using System.Data;
using Audiophile.Types;

namespace DAL;

public interface IDataAccess
{
    Task<DataTable> ExecuteAsync(string cmdText, List<Parm>? parms = null, CommandType cmdType = CommandType.StoredProcedure);

    Task<object> ExecuteScalarAsync(string cmdText, List<Parm>? parms = null, CommandType cmdType = CommandType.StoredProcedure);

    Task<int> ExecuteNonQueryAsync(string cmdText, List<Parm>? parms = null, CommandType cmdType = CommandType.StoredProcedure);

}
