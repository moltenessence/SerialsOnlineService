using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
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
            CreateMap<RatingEntity, Rating>().ReverseMap();
        }

    }
}
