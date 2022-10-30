namespace SerialsOnlineService.BLL.Models
{
    public class UserWithPurchasesDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
