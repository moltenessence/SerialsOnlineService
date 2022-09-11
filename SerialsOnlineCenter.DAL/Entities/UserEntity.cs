using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.Entities
{
    public class UserEntity : IEntityBase
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }

        public int SubscriptionId { get; set; }
    }
}
