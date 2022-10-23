using Dapper.FluentMap.Mapping;
using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.FluentMap
{
    public class SerialMap : EntityMap<SerialEntity>
    {
        public SerialMap()
        {
            Map(x => x.Id).ToColumn("serial_id");
            Map(x => x.SubscriptionId).ToColumn("subscription_id");
            Map(x => x.ReleaseYear).ToColumn("release_year");
            Map(x => x.AmountOfSeries).ToColumn("amount_of_series");
        }
    }
}
