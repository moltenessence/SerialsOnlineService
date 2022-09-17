using static SerialsOnlineCenter.DAL.Helpers.RepositoryHelper;

namespace SerialsOnlineCenter.DAL.Repositories
{
    public class RatingRepository
    {
        private readonly string _connectionString;

        public RatingRepository()
        {
            _connectionString = ConnectionString;
        }
    }
}
