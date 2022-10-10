using Microsoft.Extensions.DependencyInjection;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Service;

namespace SerialsOnlineService.BLL
{
    public static class BusinessLogicDI
    {
        public static void RegisterBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<ISerialService, SerialService>();
            services.AddTransient<IRatingService, RatingService>();
        }
    }
}
