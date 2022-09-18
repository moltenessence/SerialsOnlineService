using static SerialsOnlineCenter.DAL.Helpers.RepositoryHelper;

namespace SerialsOnlineCenter.DAL.Repositories
{
    public class SerialRepository
    {
        private readonly string _connectionString;

        public SerialRepository()
        {
            _connectionString = ConnectionString;
        }

        public async Task<SerialEntity> GetById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT FROM Serials WHERE id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SerialEntity>(command);

            return result;
        }

        public async Task<IReadOnlyList<SerialEntity>> GetOrderedByOldestReleaseYear(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var result = await connection.QueryAsync<SerialEntity>("SELECT * FROM Serials ORDER BY ReleaseYear", cancellationToken);

            return result.ToList();
        }

        public async Task<IReadOnlyList<SerialEntity>> GetOrderedByLatestReleaseYear(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var result = await connection.QueryAsync<SerialEntity>("SELECT * FROM Serials ORDER BY ReleaseYear DESC", cancellationToken);

            return result.ToList();
        }

        public async Task<IReadOnlyList<SerialEntity>> GetTopWithTheLargestAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM Serials ORDER BY AmountOfSeries DESC LIMIT @AmountOfSerials";

            var command = CreateCommand(query, new { @AmountOfSerials = amountOfSerials }, cancellationToken: cancellationToken);

            var result = await connection.QueryAsync<SerialEntity>(command);

            return result.ToList();
        }

        public async Task<IReadOnlyList<SerialEntity>> GetTopWithTheMinimalAmountOfSeries(int amountOfSerials, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM Serials ORDER BY AmountOfSeries LIMIT @AmountOfSerials";

            var command = CreateCommand(query, new { @AmountOfSerials = amountOfSerials }, cancellationToken: cancellationToken);

            var result = await connection.QueryAsync<SerialEntity>(command);

            return result.ToList();
        }

        public async Task<IReadOnlyList<SerialEntity>> GetAccordingToSubscription(int subscriptionId, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM Serials WHERE SubscriptionId = @SubscriptionId";

            var command = CreateCommand(query, new { @SubscriptionId = subscriptionId }, cancellationToken: cancellationToken);

            var result = await connection.QueryAsync<SerialEntity>(command);

            return result.ToList();
        }

        public async Task<IReadOnlyList<SerialEntity>> GetByGenre(string genre, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT FROM Serials WHERE Genre LIKE %@Genre%";

            var command = CreateCommand(query, new { @Genre = genre }, cancellationToken: cancellationToken);

            var result = await connection.QueryAsync<SerialEntity>(command);

            return result.ToList();
        }


        public async Task<IReadOnlyList<SerialEntity>> GetAll(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var result = await connection.QueryAsync<SerialEntity>("SELECT * FROM Serials", cancellationToken);

            return result.ToList();
        }

        public async Task<SerialEntity> DeleteById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "DELETE FROM Serials WHERE id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<SerialEntity>(command);

            return result;
        }

        public async Task<SerialEntity> Insert(SerialEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "INSERT INTO Serials (Name, ReleaseYear, AmountOfSeries, Description, Genre, SubscriptionId) values " +
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

            var result = await connection.QuerySingleOrDefaultAsync<SerialEntity>(command);

            return result;
        }

        public async Task<SerialEntity> Update(SerialEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "UPDATE Serials SET Name = @Name, ReleaseYear = @ReleaseYear, AmountOfSeries = @AmountOfSeries, " +
                        "Description = @Description, Genre = @Genre, SubscriptionId = @SubscriptionId WHERE Id = @Id)";

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

            var result = await connection.QuerySingleOrDefaultAsync<SerialEntity>(command);

            return result;
        }
    }
}
