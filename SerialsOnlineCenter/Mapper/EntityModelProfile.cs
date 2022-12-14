using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.EntityViews;
using SerialsOnlineCenter.DAL.FilterProperties;
using SerialsOnlineService.BLL.Filter;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Mapper
{
    public class EntityModelProfile : Profile
    {
        public EntityModelProfile()
        {
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<RatingEntity, Rating>().ReverseMap();
            CreateMap<SerialEntity, Serial>().ReverseMap();
            CreateMap<PurchaseEntity, Purchase>().ReverseMap();
            CreateMap<SubscriptionEntity, Subscription>().ReverseMap();

            CreateMap<SerialWithRequiredSubscription, SerialWithRequiredSubscriptionDTO>().ReverseMap();
            CreateMap<RatingWithUserAndSerialNames, RatingWithUserAndSerialNamesDTO>().ReverseMap();
            CreateMap<SerialsGroupedByGenre, SerialsGroupedByGenreDTO>().ReverseMap();
            CreateMap<SerialRatingsEntityView, SerialRatingsDTO>().ReverseMap();
            CreateMap<UserWithPurchasesEntityView, UserWithPurchasesDTO>().ReverseMap();

            CreateMap<SerialsFilter, SerialFilterProperties>();
            CreateMap<PurchaseDTO, PurchaseEntityView>().ReverseMap();
        }

    }
}
