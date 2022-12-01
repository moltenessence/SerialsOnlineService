using Dapper;
using MySql.Data.MySqlClient;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using static SerialsOnlineCenter.DAL.Helpers.RepositoryHelper;

namespace SerialsOnlineCenter.DAL.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly string _connectionString;

        public RatingRepository()
        {
            _connectionString = ConnectionString;
        }

        public async Task<RatingEntity> GetById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM ratings WHERE rating_id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<RatingEntity>(command);

            return result;
        }

        public async Task<RatingEntity> Insert(RatingEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "INSERT INTO ratings (value, annotation, user_id, serial_id) values (@Value, @Annotation, @UserId, @SerialId)";

            var command = CreateCommand(query, new
            {
                @Value = entity.Value,
                @Annotation = entity.Annotation,
                @UserId = entity.UserId,
                @SerialId = entity.SerialId
            },
                cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<RatingEntity>(command);

            return entity;
        }

        public async Task<IReadOnlyList<RatingEntity>> GetAll(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var result = await connection.QueryAsync<RatingEntity>("SELECT * FROM ratings", cancellationToken);

            return result.ToList();
        }

        public async Task<SerialRatingsEntityView> GetSerialRatings(int serialId, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT ratings.value as Value, ratings.annotation as Annotation, users.username as UserName FROM ratings " +
                        "JOIN users ON users.user_id = ratings.user_id " +
                        "WHERE serial_id = @Id";

            var command = CreateCommand(query, new { @Id = serialId }, cancellationToken: cancellationToken);

            var ratings = await connection.QueryAsync<SerialRating>(command);

            if (ratings is not null)
            {
                var avgRatingQuery = "SELECT AVG(ratings.value) AS AverageRating FROM ratings";

                var avgRatingCommand = CreateCommand(avgRatingQuery, new { @Id = serialId }, cancellationToken: cancellationToken);

                var avgRatingResult = await connection.QueryFirstOrDefaultAsync<SerialAverageRating>(avgRatingCommand);

                var result = new SerialRatingsEntityView(ratings.ToList(), Math.Round(avgRatingResult.AverageRating, 2));

                return result;
            }

            return new SerialRatingsEntityView(new List<SerialRating>(), 0.0M); ;
        }

        public async Task<IReadOnlyList<RatingWithUserAndSerialNames>> GetWithUsersAndSerialNames(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT ratings.value as Value, ratings.annotation as Annotation, users.username as UserName, serials.name as SerialName FROM ratings " +
                        "JOIN users ON users.user_id = ratings.user_id " +
                        "JOIN serials ON serials.serial_id = ratings.serial_id";

            var result = await connection.QueryAsync<RatingWithUserAndSerialNames>(query, cancellationToken);

            return result.ToList();
        }

        public async Task<RatingEntity> Update(RatingEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "UPDATE ratings SET value = @Value, annotation = @Annotation WHERE rating_id = @Id";

            var command = CreateCommand(query, new
            {
                @Id = entity.Id,
                @Value = entity.Value,
                @Annotation = entity.Annotation,
                @SerialId = entity.SerialId,
                @UserId = entity.UserId
            },
                cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<RatingEntity>(command);

            return entity;
        }


        public async Task<RatingEntity> DeleteById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "DELETE FROM ratings WHERE rating_id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<RatingEntity>(command);

            return result;
        }
    }
}
