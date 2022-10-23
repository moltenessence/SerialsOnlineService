namespace SerialsOnlineCenter.ViewModels
{
    public record UserViewModel(int Id,
        string UserName,
        string Email,
        int? Age,
        int SubscriptionId);
}
