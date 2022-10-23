using Dapper.FluentMap.Mapping;
using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.FluentMap
{
    public class RatingMap : EntityMap<RatingEntity>
    {
        public RatingMap()
        {
            Map(x => x.Id).ToColumn("rating_id");
        }
    }
}
