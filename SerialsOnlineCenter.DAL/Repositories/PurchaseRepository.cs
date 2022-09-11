using Dapper;
using MySql.Data.MySqlClient;
using SerialsOnlineCenter.DAL.Entities;
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

            var query = "SELECT FROM Purchases WHERE id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<PurchaseEntity>(command);

            return result;
        }

        public async Task<IReadOnlyList<PurchaseEntity>> GetAll(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var result = await connection.QueryAsync<PurchaseEntity>("SELECT * FROM Purchases", cancellationToken);

            return result.ToList();
        }

        public async Task<PurchaseEntity> DeleteById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var query = "DELETE FROM Purchases WHERE id = @Id;";

            var command = CreateCommand(query, new { @Id = id, @DefaultSubscriptionId = 1 }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<PurchaseEntity>(command);

            return result;
        }

        public async Task<PurchaseEntity> Insert(PurchaseEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var query = "INSERT INTO Purchases (Date, AmountOfMonths, TotalPrice, UserId, SubscriptionId) " +
                        "values (@Date, @AmountOfMonths, @TotalPrice, @UserId ,@SubscriptionId); " +
                        "UPDATE Users SET SubscriptionId = @SubscriptionId WHERE Id = @UserId";

            var command = CreateCommand(query, new
            { @Date = entity.Date, @AmountOfMonths = entity.AmountOfMonths, @TotalPrice = entity.TotalPrice, @UserId = entity.UserId, @SubscriptionId = entity.SubscriptionId },
                cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<PurchaseEntity>(command);

            return result;
        }

        public async Task<IReadOnlyList<PurchaseEntity>> GetTopPurchasesByMaxTotalPrice(int amountOfPurchases, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());

            var query = "SELECT * FROM Purchases ORDER BY TotalPrice LIMIT @AmountOfPurchases";

            var command = CreateCommand(query, new { @AmountOfPurchases = amountOfPurchases });

            var result = await connection.QuerySingleOrDefaultAsync<IReadOnlyList<PurchaseEntity>>(command);

            return result;
        }
    }
}
