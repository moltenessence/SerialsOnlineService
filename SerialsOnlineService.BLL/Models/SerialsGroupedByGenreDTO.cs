using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record SerialsGroupedByGenreDTO(string Genre, int Amount) : IModel;
}
