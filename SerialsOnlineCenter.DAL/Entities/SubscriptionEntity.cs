using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.Entities
{
    public class SubscriptionEntity : IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal PricePerMonth { get; set; }
    }
}
