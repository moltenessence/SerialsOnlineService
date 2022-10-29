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

            var query = "INSERT INTO ratings (value, annotation) values (@Value, @Annotation)";

            var command = CreateCommand(query, new
            {
                @Value = entity.Value,
                @Annotation = entity.Annotation
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

        public async Task<RatingEntity> SetForSerial(int userId, int serialId, int ratingId, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var rating = await GetById(ratingId, cancellationToken);

            if (rating != null)
            {
                var query = "INSERT INTO users_ratings (user_id, rating_id) values (@UserId, @RatingId);" +
                            "INSERT INTO serials_ratings (serial_id, rating_id) values (@SerialId, @RatingId);";

                var command = CreateCommand(query, new
                {
                    @UserId = userId,
                    @SerialId = serialId,
                    @RatingId = rating.Id,
                }, cancellationToken: cancellationToken);

                var result = await connection.QuerySingleOrDefaultAsync<RatingEntity>(command);

                return result;
            }

            return rating;
        }

        public async Task<double> GetSerialRating(int serialId, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT AVG(ratings.value) AS AverageRating FROM ratings WHERE rating_id = ANY (SELECT rating_id from serials_ratings WHERE serial_id = @Id)";

            var command = CreateCommand(query, new { @Id = serialId }, cancellationToken: cancellationToken);

            var result = await connection.QueryFirstOrDefaultAsync<SerialAverageRating>(command);

            return Convert.ToDouble(result.AverageRating);
        }

        public async Task<IReadOnlyList<RatingWithUserAndSerialNames>> GetWithUsersAndSerialNames(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT ratings.value as Value, ratings.annotation as Annotation, users.username as UserName, serials.name as SerialName FROM ratings " +
                        "JOIN users_ratings ON users_ratings.rating_id = ratings.rating_id " +
                        "JOIN serials_ratings ON serials_ratings.rating_id = users_ratings.rating_id " +
                        "JOIN users ON users.user_id = users_ratings.user_id " +
                        "JOIN serials ON serials.serial_id = serials_ratings.serial_id";

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
