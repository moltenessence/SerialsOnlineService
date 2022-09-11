using SerialsOnlineCenter.DAL.Interfaces;

namespace SerialsOnlineCenter.DAL.Entities
{
    public class PurchaseEntity : IEntityBase
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int AmountOfMonths { get; set; }
        public decimal TotalPrice { get; set; }

        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
    }
}
