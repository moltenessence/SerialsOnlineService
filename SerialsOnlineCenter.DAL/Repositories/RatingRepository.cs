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

        public async Task<RatingEntity> Insert(int userId, int serialId, RatingEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var insertRatingQuery = "INSERT INTO Ratings (Value, Annotation) values (@Value, @Annotation)";

            var insertRatingCommand = CreateCommand(insertRatingQuery, new
            {
                @Value = entity.Value,
                @Annotation = entity.Annotation
            }, cancellationToken: cancellationToken);

            var rating = await connection.QuerySingleOrDefaultAsync<RatingEntity>(insertRatingCommand);

            if (rating != null)
            {
                var query = "INSERT INTO UsersRatings (UserId, RatingId) values (@UserId, @RatingId);" +
                            "INSERT INTO SerialsRatings (SerialId, RatingId) values (@SerialId, @RatingId);";

                var command = CreateCommand(insertRatingQuery, new
                {
                    @UserId = userId,
                    @SerialId = serialId,
                    @RatingId = rating.Id,
                }, cancellationToken: cancellationToken);

                var result = await connection.QuerySingleOrDefaultAsync<RatingEntity>(insertRatingCommand);

                return result;
            }

            return rating;
        }

        public async Task<double> GetSerialRating(int serialId, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT AVG(SerialRatings.Value) FROM SerialRatings WHERE @Id = RatingId";

            var command = CreateCommand(query, new { @Id = serialId }, cancellationToken: cancellationToken);

            var result = await connection.QueryFirstOrDefaultAsync<double>(query, cancellationToken);

            return result;
        }

        public async Task<IReadOnlyList<RatingWithUserAndSerialNames>> GetAll(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT Ratings.Value, Ratings.Annotation, Users.UserName, Serials.Name AS SerialName " +
                        "FROM Ratings " +
                        "JOIN UsersRatings ON UsersRatings.UserId = UsersRatings.RatingId " +
                        "JOIN SerialsRatings ON SerialsRatings.SerialId = SerialsRatings.RatingId " +
                        "JOIN Users ON Users.Id = UsersRatings.UserId " +
                        "JOIN Serials ON Serials.Id = SerialsRatings.SerialId";

            var result = await connection.QueryAsync<RatingWithUserAndSerialNames>(query, cancellationToken);

            return result.ToList();
        }

        public async Task<RatingEntity> Update(RatingEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "UPDATE Ratings SET Value = @Value, Annotation = @Annotation WHERE Id = @Id)";

            var command = CreateCommand(query, new
            {
                @Id = entity.Id,
                @Value = entity.Value,
            },
                cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<RatingEntity>(command);

            return result;
        }


        public async Task<RatingEntity> DeleteById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "DELETE FROM Ratings WHERE id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<RatingEntity>(command);

            return result;
        }
    }
}
