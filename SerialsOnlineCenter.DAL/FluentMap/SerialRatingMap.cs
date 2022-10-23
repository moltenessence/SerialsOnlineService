using Dapper.FluentMap.Mapping;
using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.FluentMap
{
    public class SerialRatingMap : EntityMap<SerialsRatingsEntity>
    {
        public SerialRatingMap()
        {
            Map(x => x.Id).ToColumn("serials_ratings_id");
            Map(x => x.RatingId).ToColumn("rating_id");
            Map(x => x.SerialId).ToColumn("serial_id");
        }
    }
}
