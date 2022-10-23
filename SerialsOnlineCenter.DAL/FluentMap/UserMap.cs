using Dapper.FluentMap.Mapping;
using SerialsOnlineCenter.DAL.Entities;

namespace SerialsOnlineCenter.DAL.FluentMap
{
    public class UserMap : EntityMap<UserEntity>
    {
        public UserMap()
        {
            Map(x => x.Id).ToColumn("user_id");
            Map(x => x.SubscriptionId).ToColumn("subscription_id");
            Map(x => x.UserName).ToColumn("username");
        }
    }
}
