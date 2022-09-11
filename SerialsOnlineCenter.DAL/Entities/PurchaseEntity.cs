namespace SerialsOnlineCenter.DAL.Entities
{
    public class PurchaseEntity
    {
        public int PurchaseId { get; set; }
        public DateOnly Date { get; set; }
        public int AmountOfMonths { get; set; }
        public decimal TotalPrice { get; set; }

        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
    }
}
