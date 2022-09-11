using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SerialsOnlineCenter.DAL.Helpers;
using SerialsOnlineCenter.DAL.Interfaces;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineCenter.DAL.Repositories;
using System.Reflection;

namespace SerialsOnlineCenter.DAL
{
    public static class DataAccessDI
    {
        public static void RegisterDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            RepositoryHelper.ConnectionString = configuration.GetConnectionString("DbConnection");
            RepositoryHelper.SysConnectionString = configuration.GetConnectionString("SysConnection");

            services.AddTransient<IDatabaseCreator, DatabaseCreator>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();

            services.AddFluentMigratorCore().ConfigureRunner(config =>
                    config.AddMySql5().WithGlobalConnectionString(RepositoryHelper.ConnectionString)
                        .ScanIn(Assembly.GetExecutingAssembly()).For.All())
                .AddLogging(config => config.AddFluentMigratorConsole());
        }
    }
}
