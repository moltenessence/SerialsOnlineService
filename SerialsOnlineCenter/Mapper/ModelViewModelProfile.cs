using AutoMapper;
using SerialsOnlineCenter.ViewModels;
using SerialsOnlineCenter.ViewModels.Rating;
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

            CreateMap<RatingWithUserAndSerialNamesDTO, RatingWithUserAndSerialNamesViewModel>().ReverseMap();
            CreateMap<Rating, PostRatingViewModel>().ReverseMap();
        }
    }
}
