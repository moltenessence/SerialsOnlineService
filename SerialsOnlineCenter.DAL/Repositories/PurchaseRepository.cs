using Dapper;
using MySql.Data.MySqlClient;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;
using SerialsOnlineCenter.DAL.Helpers;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using static SerialsOnlineCenter.DAL.Helpers.RepositoryHelper;

namespace SerialsOnlineCenter.DAL.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly string _connectionString;

        public PurchaseRepository()
        {
            _connectionString = ConnectionString;
        }

        public async Task<PurchaseEntity> GetById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var query = "SELECT * FROM purchases WHERE purchase_id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<PurchaseEntity>(command);

            return result;
        }

        public async Task<IReadOnlyList<PurchaseEntityView>> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var query = "SELECT purchase_id as Id, amount_of_months as AmountOfMonths, date as Date, " +
                        "total_price as TotalPrice, subscriptions.name as Subscription FROM purchases " +
                        "JOIN subscriptions ON purchases.subscription_id = subscriptions.subscription_id " +
                        "WHERE user_id = @Id";

            var command = CreateCommand(query, new { @Id = userId }, cancellationToken: cancellationToken);

            var result = await connection.QueryAsync<PurchaseEntityView>(command);

            return result.ToList();
        }

        public async Task<IReadOnlyList<PurchaseEntity>> GetAll(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var result = await connection.QueryAsync<PurchaseEntity>("SELECT * FROM purchases", cancellationToken);

            return result.ToList();
        }

        public async Task<PurchaseEntity> Update(PurchaseEntity entity, CancellationToken cancellationToken)
        {

            await using var connection = new MySqlConnection(_connectionString);

            var query = "UPDATE purchases SET amount_of_months = @AmountOfMonths, date = @Date, total_price = @TotalPrice, " +
                        "user_id = @UserId, subscription_id = @SubscriptionId WHERE purchase_id = @Id";

            var command = CreateCommand(query, new
            {
                @Id = entity.Id,
                @AmountOfMonths = entity.AmountOfMonths,
                @Date = entity.Date,
                @TotalPrice = entity.TotalPrice,
                @UserId = entity.UserId,
                @SubscriptionId = entity.SubscriptionId
            },
                cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<PurchaseEntity>(command);

            return entity;
        }

        public async Task<PurchaseEntity> DeleteById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var query = "DELETE FROM purchases WHERE purchase_id = @Id;";

            var command = CreateCommand(query, new { @Id = id, @DefaultSubscriptionId = 1 }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<PurchaseEntity>(command);

            return result;
        }

        public async Task<PurchaseEntity> Insert(PurchaseEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var query = "INSERT INTO purchases (date, amount_of_months, total_price, user_id, subscription_id) " +
                        "values (@Date, @AmountOfMonths, @TotalPrice, @UserId ,@SubscriptionId); " +
                        "UPDATE users SET subscription_id = @SubscriptionId WHERE user_id = @UserId";

            var command = CreateCommand(query, new
            { @Date = entity.Date, @AmountOfMonths = entity.AmountOfMonths, @TotalPrice = entity.TotalPrice, @UserId = entity.UserId, @SubscriptionId = entity.SubscriptionId },
                cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<PurchaseEntity>(command);

            return entity;
        }

        public async Task<IReadOnlyList<PurchaseEntity>> GetTopPurchasesByMaxTotalPrice(int amountOfPurchases, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var query = "SELECT * FROM purchases ORDER BY total_price DESC LIMIT @AmountOfPurchases";

            var command = CreateCommand(query, new { @AmountOfPurchases = amountOfPurchases }, cancellationToken: cancellationToken);

            var result = await connection.QueryAsync<PurchaseEntity>(command);

            return result.ToList();
        }
    }
}
