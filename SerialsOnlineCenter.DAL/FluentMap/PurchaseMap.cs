using Dapper.FluentMap.Mapping;
using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.FluentMap
{
    public class PurchaseMap : EntityMap<PurchaseEntity>
    {
        public PurchaseMap()
        {
            Map(x => x.AmountOfMonths).ToColumn("amount_of_months");
            Map(x => x.Id).ToColumn("purchase_id");
            Map(x => x.SubscriptionId).ToColumn("subscription_id");
            Map(x => x.TotalPrice).ToColumn("total_price");
        }
    }
}
