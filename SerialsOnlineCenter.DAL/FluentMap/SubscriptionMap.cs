using Dapper.FluentMap.Mapping;
using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.FluentMap
{
    public class SubscriptionMap : EntityMap<SubscriptionEntity>
    {
        public SubscriptionMap()
        {
            Map(x => x.Id).ToColumn("subscription_id");
            Map(x => x.PricePerMonth).ToColumn("price_per_month");
        }
    }
}
