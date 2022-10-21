using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record RatingWithUserAndSerialNamesDTO(int Value, string UserName, string SerialName, string? Description) : IModel;
}
