using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Interface.Services
{
    public interface IAuthService
    {
        Task<bool> Login(LoginModel loginModel, CancellationToken cancellationToken);
    }
}
