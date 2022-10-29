using Dapper;
using MySql.Data.MySqlClient;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using static SerialsOnlineCenter.DAL.Helpers.RepositoryHelper;

namespace SerialsOnlineCenter.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository()
        {
            _connectionString = ConnectionString;
        }

        public async Task<UserEntity> GetById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "SELECT * FROM users WHERE user_id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<UserEntity>(command);

            return result;
        }

        public async Task<IReadOnlyList<UserEntity>> GetAll(CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var result = await connection.QueryAsync<UserEntity>("SELECT * FROM users", cancellationToken);

            return result.ToList();
        }

        public async Task<UserEntity> DeleteById(int id, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "DELETE FROM users WHERE user_id = @Id";

            var command = CreateCommand(query, new { @Id = id }, cancellationToken: cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync<UserEntity>(command);

            return result;
        }

        public async Task<UserEntity> Insert(UserEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "INSERT INTO users (username, email, age, subscription_id) values (@UserName, @Email, @Age, @SubscriptionId)";

            var command = CreateCommand(query, new
            { @UserName = entity.UserName, @Email = entity.Email, @Age = entity.Age, @SubscriptionId = entity.SubscriptionId },
                cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<UserEntity>(command);

            return entity;
        }

        public async Task<UserEntity> Update(UserEntity entity, CancellationToken cancellationToken)
        {
            await using var connection = new MySqlConnection(_connectionString);

            var query = "UPDATE users SET username = @UserName, email = @Email, age = @Age, subscription_id = @SubscriptionId WHERE user_id = @Id";

            var command = CreateCommand(query, new
            { @Id = entity.Id, @UserName = entity.UserName, @Email = entity.Email, @Age = entity.Age, @SubscriptionId = entity.SubscriptionId },
                cancellationToken: cancellationToken);

            await connection.QuerySingleOrDefaultAsync<UserEntity>(command);

            return entity;
        }
    }
}

