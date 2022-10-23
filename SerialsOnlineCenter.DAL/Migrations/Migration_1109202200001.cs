using FluentMigrator;


namespace SerialsOnlineCenter.DAL.Migrations
{
    [Migration(1109202200001)]
    public class Migration_1109202200001 : Migration
    {
        public override void Up()
        {
            //Insert.IntoTable("subscriptions")
            //    .Row(new SubscriptionEntity()
            //    {
            //        Id = 1,
            //        Name = "Default",
            //        PricePerMonth = 10.0M
            //    })
            //    .Row(new SubscriptionEntity()
            //    {
            //        Id = 2,
            //        Name = "Family",
            //        PricePerMonth = 25.0M
            //    })
            //    .Row(new SubscriptionEntity()
            //    {
            //        Id = 3,
            //        Name = "Extented",
            //        PricePerMonth = 34.0M
            //    })
            //    .Row(new SubscriptionEntity()
            //    {
            //        Id = 4,
            //        Name = "Premium",
            //        PricePerMonth = 46.6M
            //    });
        }

        public override void Down()
        {
        }
    }
}
