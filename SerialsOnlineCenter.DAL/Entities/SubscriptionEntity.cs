namespace SerialsOnlineCenter.DAL.Entities
{
    public class SubscriptionEntity
    {
        public int SubscriptionId { get; set; }

        public string Name { get; set; }
        public decimal PricePerMonth { get; set; }
    }
}
