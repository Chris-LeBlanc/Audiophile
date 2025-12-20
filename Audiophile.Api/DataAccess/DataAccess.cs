using System.Data;
using Audiophile.Types;
using Microsoft.Extensions.Configuration.Json;
using Audiophile.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace DAL
{
    public class DataAccess : IDataAccess
    {
        private readonly string? _connectionString;

        public DataAccess(IOptions<DatabaseOptions> options)
        {
           _connectionString = options.Value.AudiophileConnStr;
        }

        public async Task<DataTable> ExecuteAsync(string cmdText, List<Parm>? parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            DataTable dt = new();
            SqlCommand cmd = CreateCommand(cmdText, parms, cmdType);

            using (cmd.Connection)
            {
                SqlDataAdapter da = new(cmd);

                await Task.Run(() => da.Fill(dt));
            }

            return dt;
        }

        public async Task<object?> ExecuteScalarAsync(string cmdText, List<Parm>? parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            object? retVal;
            SqlCommand cmd = CreateCommand(cmdText, parms, cmdType);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                retVal = await cmd.ExecuteScalarAsync();
            }

            return retVal;
        }

        public async Task<int> ExecuteNonQueryAsync(string cmdText, List<Parm>? parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            int rowsAffected = 0;
            SqlCommand cmd = CreateCommand(cmdText, parms, cmdType);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                rowsAffected = await cmd.ExecuteNonQueryAsync();

                UnloadParms(parms, cmd);
            }

            return rowsAffected;
        }

        private SqlCommand CreateCommand(string cmdText, List<Parm>? parms, CommandType cmdType)
        {
            SqlConnection conn = new(_connectionString);
            SqlCommand cmd = new(SQLCleaner(cmdText), conn) { CommandType = cmdType };

            if (parms != null)
                foreach (Parm p in parms)
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = p.Name,
                        SqlDbType = p.DataType,
                        Size = p.Size,
                        Value = p.Value,
                        Direction = p.Direction
                    });
                }

            return cmd;
        }

        private void UnloadParms(List<Parm>? parms, SqlCommand cmd)
        {
            if (parms is null) return;

            for (int i = 0; i < parms.Count; i++)
            {
                parms[i].Value = cmd.Parameters[i].Value;
            }
        }

        private string SQLCleaner(string sql)
        {
            while (sql.Contains("  "))
                sql = sql.Replace("  ", " ");

            while (sql.Contains('\t'))
                sql = sql.Replace("\t", "");

            return sql.Replace(Environment.NewLine, "");
        }
    }
}