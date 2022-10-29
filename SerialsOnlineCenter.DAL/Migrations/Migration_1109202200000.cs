using FluentMigrator;
using System.Data;

namespace SerialsOnlineCenter.DAL.Migrations
{
    [Migration(1109202200000)]
    public class Migration_1109202200000 : Migration
    {
        public override void Up()
        {
            Create.Table("subscriptions")
                .WithColumn("subscription_id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("name").AsString(60).NotNullable()
                .WithColumn("price_per_month").AsDecimal().NotNullable();

            Create.Table("users")
                .WithColumn("user_id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("age").AsInt32().NotNullable()
                .WithColumn("username").AsString(50).NotNullable()
                .WithColumn("email").AsString(60).NotNullable()
                .WithColumn("subscription_id").AsInt32().NotNullable().ForeignKey("subscriptions", "subscription_id");

            Create.Table("purchases")
                .WithColumn("purchase_id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("date").AsDate().NotNullable()
                .WithColumn("amount_of_months").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("total_price").AsDecimal().NotNullable()
                .WithColumn("user_id").AsInt32().NotNullable().ForeignKey("users", "user_id")
                .WithColumn("subscription_id").AsInt32().NotNullable().ForeignKey("subscriptions", "subscription_id");

            Create.Table("serials")
                .WithColumn("serial_id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("name").AsString(60).NotNullable()
                .WithColumn("amount_of_series").AsInt32().NotNullable()
                .WithColumn("description").AsString(1000)
                .WithColumn("genre").AsString(50).NotNullable()
                .WithColumn("release_year").AsInt32().NotNullable()
                .WithColumn("subscription_id").AsInt32().NotNullable().WithDefaultValue(1).ForeignKey("subscriptions", "subscription_id");

            Create.Table("ratings")
                .WithColumn("rating_id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("value").AsInt32().NotNullable()
                .WithColumn("annotation").AsString(1000)
                .WithColumn("serial_id").AsInt32().NotNullable().ForeignKey("serials", "serial_id").OnDelete(Rule.Cascade)
                .WithColumn("user_id").AsInt32().NotNullable().ForeignKey("users", "user_id").OnDelete(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("purchases");
            Delete.Table("ratings");
            Delete.Table("serials");
            Delete.Table("users");
            Delete.Table("subscriptions");
        }
    }
}
