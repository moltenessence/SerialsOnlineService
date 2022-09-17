using FluentMigrator.Runner;
using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.Extensions
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase(this WebApplication app)
        {
            using var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope();

            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            var dbCreator = scope.ServiceProvider.GetService<IDatabaseCreator>();

            dbCreator.CreateDatabase("serials");
            migrator.MigrateUp();
        }
    }
}
