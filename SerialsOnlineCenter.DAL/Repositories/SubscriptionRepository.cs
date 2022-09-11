using Dapper;
using MySql.Data.MySqlClient;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using static SerialsOnlineCenter.DAL.Helpers.RepositoryHelper;

namespace SerialsOnlineCenter.DAL.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly string _connectionString;

        public SubscriptionRepository()
        {
            _connectionString = ConnectionString;
        }

        public async Task<SubscriptionEntity> GetById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT FROM Subscriptions WHERE id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(command);

            return result;
        }

        public async Task<IReadOnlyList<SubscriptionEntity>> GetAll(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var result = await connection.QueryAsync<SubscriptionEntity>("SELECT * FROM Subscriptions", cancellationToken);

            return result.ToList();
        }

        public async Task<SubscriptionEntity> GetByMaxPrice(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "select * from subscriptions where PricePerMonth = (SELECT MAX(PricePerMonth) FROM Subscriptions); ";

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(query, cancellationToken);

            return result;
        }

        public async Task<SubscriptionEntity> GetByMinPrice(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "select * from subscriptions where PricePerMonth = (SELECT MIN(PricePerMonth) FROM Subscriptions); ";

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(query, cancellationToken);

            return result;
        }

        public async Task<decimal> GetAverageSubscriptionPrice(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "select AVG(Price) from subscriptions;";

            var result = await connection.QuerySingleOrDefaultAsync<decimal>(query, cancellationToken);

            return result;
        }
    }
}
