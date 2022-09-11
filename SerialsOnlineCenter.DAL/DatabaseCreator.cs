using Dapper;
using MySql.Data.MySqlClient;
using SerialsOnlineCenter.DAL.Interfaces;
using System.Data;
using static SerialsOnlineCenter.DAL.Helpers.RepositoryHelper;

namespace SerialsOnlineCenter.DAL
{
    public class DatabaseCreator : IDatabaseCreator
    {
        private readonly string _connectionString;

        public DatabaseCreator()
        {
            _connectionString = SysConnectionString;
        }
        public void CreateDatabase(string dbName)
        {
            using var connection = new MySqlConnection(SysConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Name", dbName, DbType.String, ParameterDirection.Input);

            connection.Execute($"CREATE DATABASE IF NOT EXISTS {dbName};");
        }
    }
}
