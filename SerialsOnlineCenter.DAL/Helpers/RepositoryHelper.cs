using Dapper;
using System.Data;

namespace SerialsOnlineCenter.DAL.Helpers
{
    internal static class RepositoryHelper
    {
        public static string ConnectionString { get; set; }
        public static string SysConnectionString { get; set; }

        public static CommandDefinition CreateCommand(
            string commandText, object parameters = null,
            IDbTransaction? transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CommandFlags flags = CommandFlags.Buffered,
            CancellationToken cancellationToken = default)
        {
            return new CommandDefinition(
                commandText, parameters, transaction,
                commandTimeout,
                commandType, flags, cancellationToken);
        }
    }
}
