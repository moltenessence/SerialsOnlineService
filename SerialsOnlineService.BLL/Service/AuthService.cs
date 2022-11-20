using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ISubscriptionService _subscriptionService;

        public AuthService(IUserService userService, ISubscriptionService subscriptionService)
        {
            _userService = userService;
            _subscriptionService = subscriptionService;
        }

        public async Task<bool> Login(LoginModel loginModel, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmail(loginModel.User.Email, cancellationToken);

            if (user is null)
            {
                var defaultSubscription = await _subscriptionService.GetByMinPrice(cancellationToken);

                if (defaultSubscription is null)
                {
                    return false;
                }

                loginModel.User.SubscriptionId = defaultSubscription.Id;

                await _userService.Insert(loginModel.User, cancellationToken);
            }

            return true;
        }
    }
}
