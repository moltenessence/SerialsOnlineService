using Dapper;
using MySql.Data.MySqlClient;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;
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

            var query = "SELECT * FROM subscriptions WHERE subscription_id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(command);

            return result;
        }

        public async Task<IReadOnlyList<SubscriptionEntity>> GetAll(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var result = await connection.QueryAsync<SubscriptionEntity>("SELECT * FROM subscriptions", cancellationToken);

            return result.ToList();
        }

        public async Task<SubscriptionEntity> GetByMaxPrice(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM subscriptions WHERE price_per_month = (SELECT MAX(price_per_month) FROM subscriptions); ";

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(query, cancellationToken);

            return result;
        }

        public async Task<SubscriptionEntity> GetByMinPrice(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM subscriptions WHERE price_per_month = (SELECT MIN(price_per_month) FROM subscriptions); ";

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(query, cancellationToken);

            return result;
        }

        public async Task<decimal> GetAveragePrice(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT AVG(price_per_month) AS AveragePrice FROM subscriptions";

            var result = await connection.QueryFirstOrDefaultAsync<SubscriptionAveragePrice>(query, cancellationToken);

            return result.AveragePrice;
        }

        public async Task<SubscriptionEntity> DeleteById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "DELETE FROM subscriptions WHERE subscription_id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(command);

            return result;
        }

        public async Task<SubscriptionEntity> Insert(SubscriptionEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "INSERT INTO subscriptions (name, price_per_month) values (@Name, @PricePerMonth)";

            var command = CreateCommand(query, new { @Name = entity.Name, @PricePerMonth = entity.PricePerMonth },
                cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(command);

            return entity;
        }

        public async Task<SubscriptionEntity> Update(SubscriptionEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "UPDATE subscriptions SET name = @Name, price_per_month = @PricePerMonth WHERE subscription_id = @Id";

            var command = CreateCommand(query, new
            { @Id = entity.Id, @Name = entity.Name, @PricePetMonth = entity.PricePerMonth },
                cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(command);

            return result;
        }
    }
}
