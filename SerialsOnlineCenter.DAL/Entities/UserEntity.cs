namespace SerialsOnlineCenter.DAL.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }

        public int SubscriptionId { get; set; }
    }
}
