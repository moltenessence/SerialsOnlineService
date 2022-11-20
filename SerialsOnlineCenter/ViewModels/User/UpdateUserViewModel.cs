namespace SerialsOnlineCenter.ViewModels.User
{
    public record UpdateUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public int SubscriptionId { get; set; }
    }
}
