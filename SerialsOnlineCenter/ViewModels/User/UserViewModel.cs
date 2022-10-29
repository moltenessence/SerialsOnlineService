namespace SerialsOnlineCenter.ViewModels.User
{
    public record UserViewModel(int Id,
        string UserName,
        string Email,
        int? Age,
        int SubscriptionId);
}
