using Dapper;
using MySql.Data.MySqlClient;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;
using SerialsOnlineCenter.DAL.FilterProperties;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineCenter.DAL.QueryCreators.Serials;
using static SerialsOnlineCenter.DAL.Helpers.RepositoryHelper;

namespace SerialsOnlineCenter.DAL.Repositories
{
    public class SerialRepository : ISerialRepository
    {
        private readonly string _connectionString;

        public SerialRepository()
        {
            _connectionString = ConnectionString;
        }

        public async Task<SerialEntity> GetById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT FROM serials WHERE serial_id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SerialEntity>(command);

            return result;
        }

        public async Task<IReadOnlyList<SerialEntity>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM serials WHERE subscription_id = @SubscriptionId";

            var command = CreateCommand(query, new { @SubscriptionId = subscriptionId }, cancellationToken: cancellationToken);

            var result = await connection.QueryAsync<SerialEntity>(command);

            return result.ToList();
        }

        public async Task<IReadOnlyList<SerialEntity>> GetAll(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var result = await connection.QueryAsync<SerialEntity>("SELECT * FROM serials", cancellationToken);

            return result.ToList();
        }

        public async Task<SerialEntity> DeleteById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "DELETE FROM Serials WHERE serial_id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SerialEntity>(command);

            return result;
        }

        public async Task<SerialEntity> Insert(SerialEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "INSERT INTO Serials (name, release_year, amount_of_series, description, genre, subscription_id) values " +
                        "(@Name, @ReleaseYear, @AmountOfSeries, @Description, @Genre, @SubscriptionId)";

            var command = CreateCommand(query, new
            {
                @Name = entity.Name,
                @ReleaseYear = entity.ReleaseYear,
                @AmountOfSeries = entity.AmountOfSeries,
                @Description = entity.Description,
                @Genre = entity.Genre,
                @SubscriptionId = entity.SubscriptionId
            },
                cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<SerialEntity>(command);

            return entity;
        }

        public async Task<SerialEntity> Update(SerialEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "UPDATE Serials SET Name = @Name, release_year = @ReleaseYear, amount_of_series = @AmountOfSeries, " +
                        "description = @Description, genre = @Genre, subscription_id = @SubscriptionId WHERE serial_id = @Id";

            var command = CreateCommand(query, new
            {
                @Id = entity.Id,
                @Name = entity.Name,
                @ReleaseYear = entity.ReleaseYear,
                @AmountOfSeries = entity.AmountOfSeries,
                @Description = entity.Description,
                @Genre = entity.Genre,
                @SubscriptionId = entity.SubscriptionId
            },
               cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<SerialEntity>(command);

            return entity;
        }

        public async Task<IReadOnlyList<SerialWithRequiredSubscription>> GetWithRequiredSubscription(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT serials.name AS Name, serials.description AS Description, serials.genre AS Genre, subscriptions.name AS RequiredSubscription" +
                        " FROM serials JOIN subscriptions ON serials.subscription_id = subscriptions.subscription_id";

            var result = await connection.QueryAsync<SerialWithRequiredSubscription>(query, cancellationToken);

            return result.ToList();
        }

        public async Task<IReadOnlyList<SerialsGroupedByGenre>> GetGroupedByGenre(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT genre AS Genre, COUNT(*) AS Amount FROM serials GROUP BY genre";

            var result = await connection.QueryAsync<SerialsGroupedByGenre>(query, cancellationToken);

            return result.ToList();
        }

        public async Task<IReadOnlyList<SerialEntity>> GetByFilterProperties(SerialFilterProperties? props, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = new GetSerialsQueryCreator(props).Query();

            var command = CreateCommand(query, new
            {
                @SerialName = props?.Name,
                @AmountOfSeries = props?.AmountOfSeries,
                @ReleaseYear = props?.ReleaseYear,
            }, cancellationToken: cancellationToken);

            var serials = await connection.QueryAsync<SerialEntity>(command);

            var result = serials.ToList();

            if (!result.Any()) return await GetAll(cancellationToken);

            return result;
        }

        public async Task<IReadOnlyList<string>> GetAllGenres(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT genre FROM serials";

            var result = await connection.QueryAsync<string>(query, cancellationToken);

            return result.ToList();
        }
    }
}
