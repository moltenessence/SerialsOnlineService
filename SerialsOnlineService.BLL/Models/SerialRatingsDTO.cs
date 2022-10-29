using SerialsOnlineCenter.DAL.EntityViews;
using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record SerialRatingsDTO(IReadOnlyList<SerialRating> SerialRatings = default, decimal Average = default) : IModel;
}
