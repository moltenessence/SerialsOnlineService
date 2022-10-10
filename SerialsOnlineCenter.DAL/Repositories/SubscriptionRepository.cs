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

            var query = "SELECT * FROM Subscriptions WHERE PricePerMonth = (SELECT MAX(PricePerMonth) FROM Subscriptions); ";

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(query, cancellationToken);

            return result;
        }

        public async Task<SubscriptionEntity> GetByMinPrice(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM Subscriptions WHERE PricePerMonth = (SELECT MIN(PricePerMonth) FROM Subscriptions); ";

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(query, cancellationToken);

            return result;
        }

        public async Task<decimal> GetAveragePrice(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT AVG(Price) FROM Subscriptions";

            var result = await connection.QueryFirstOrDefaultAsync(query, cancellationToken);

            return result.ToList();
        }

        public async Task<SubscriptionEntity> DeleteById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "DELETE FROM Subscriptions WHERE id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(command);

            return result;
        }

        public async Task<SubscriptionEntity> Insert(SubscriptionEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "INSERT INTO Subscriptions (Name, PricePerMonth) values (@Name, @PricePerMonth)";

            var command = CreateCommand(query, new { @Name = entity.Name, @PricePerMonth = entity.PricePerMonth },
                cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(command);

            return entity;
        }

        public async Task<SubscriptionEntity> Update(SubscriptionEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "UPDATE Subscriptions SET Name = @Name, PricePerMonth = @PricePerMonth WHERE Id = @Id)";

            var command = CreateCommand(query, new
            { @Id = entity.Id, @Name = entity.Name, @PricePetMonth = entity.PricePerMonth },
                cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SubscriptionEntity>(command);

            return result;
        }
    }
}
