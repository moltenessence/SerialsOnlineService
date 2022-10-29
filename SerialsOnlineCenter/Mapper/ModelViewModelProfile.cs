using AutoMapper;
using SerialsOnlineCenter.ViewModels.Purchase;
using SerialsOnlineCenter.ViewModels.Rating;
using SerialsOnlineCenter.ViewModels.Serial;
using SerialsOnlineCenter.ViewModels.Subscription;
using SerialsOnlineCenter.ViewModels.User;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Mapper
{
    public class ModelViewModelProfile : Profile
    {
        public ModelViewModelProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Purchase, PurchaseViewModel>().ReverseMap();
            CreateMap<Rating, RatingViewModel>().ReverseMap();
            CreateMap<Subscription, SubscriptionViewModel>().ReverseMap();
            CreateMap<Serial, SerialViewModel>().ReverseMap();

            CreateMap<PostRatingViewModel, Rating>();

            CreateMap<SerialWithRequiredSubscriptionViewModel, SerialWithRequiredSubscriptionDTO>().ReverseMap();
            CreateMap<RatingWithUserAndSerialNamesViewModel, RatingWithUserAndSerialNamesDTO>().ReverseMap();
            CreateMap<SerialsGroupedByGenreViewModel, SerialsGroupedByGenreDTO>().ReverseMap();
        }
    }
}
