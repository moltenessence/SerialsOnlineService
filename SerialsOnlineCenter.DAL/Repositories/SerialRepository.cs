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
    }
}
