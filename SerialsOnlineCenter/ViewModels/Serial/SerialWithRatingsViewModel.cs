using SerialsOnlineCenter.DAL.EntityViews;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.ViewModels.Serial
{
    public record SerialWithRatingsViewModel(SerialViewModel? Serial, SerialRatingsEntityView? Ratings);
}
