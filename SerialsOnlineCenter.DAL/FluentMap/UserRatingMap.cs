using Dapper.FluentMap.Mapping;
using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.FluentMap
{
    public class UserRatingMap : EntityMap<UsersRatingsEntity>
    {
        public UserRatingMap()
        {
            Map(x => x.Id).ToColumn("users_ratings_id");
            Map(x => x.RatingId).ToColumn("rating_id");
            Map(x => x.UserId).ToColumn("user_id");
        }
    }
}
