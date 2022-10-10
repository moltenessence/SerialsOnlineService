using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record Rating(int Value, string? Annotation) : IModel;
}
