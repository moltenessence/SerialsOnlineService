using AutoMapper;
using SerialsOnlineCenter.FilterQuery;
using SerialsOnlineCenter.ViewModels.Login;
using SerialsOnlineCenter.ViewModels.Purchase;
using SerialsOnlineCenter.ViewModels.Rating;
using SerialsOnlineCenter.ViewModels.Serial;
using SerialsOnlineCenter.ViewModels.Subscription;
using SerialsOnlineCenter.ViewModels.User;
using SerialsOnlineService.BLL.Filter;
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
            CreateMap<PostPurchaseViewModel, Purchase>();
            CreateMap<PostSerialViewModel, Serial>();
            CreateMap<PostSubscriptionViewModel, Subscription>();
            CreateMap<PostUserViewModel, User>();

            CreateMap<UpdateRatingViewModel, Rating>();
            CreateMap<UpdatePurchaseViewModel, Purchase>();
            CreateMap<UpdateSerialViewModel, Serial>();
            CreateMap<UpdateSubscriptionViewModel, Subscription>();
            CreateMap<UpdateUserViewModel, User>();

            CreateMap<SerialWithRequiredSubscriptionDTO, SerialWithRequiredSubscriptionViewModel>();
            CreateMap<RatingWithUserAndSerialNamesDTO, RatingWithUserAndSerialNamesViewModel>();
            CreateMap<SerialsGroupedByGenreDTO, SerialsGroupedByGenreViewModel>();
            CreateMap<SerialRatingsDTO, SerialRatingsViewModel>();
            CreateMap<UserWithPurchasesDTO, UserWithPurchasesViewModel>();

            CreateMap<SerialsFilterQuery, SerialsFilter>();

            CreateMap<LoginViewModel, LoginModel>().ReverseMap();
            CreateMap<PurchaseDTO, UserPurchaseViewModel>().ReverseMap();

            CreateMap<SerialWithRatings, SerialWithRatingsViewModel>().ReverseMap();
        }
    }
}
