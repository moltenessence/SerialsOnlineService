using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public class User : IModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public int? SubscriptionId { get; set; }
    };
}
