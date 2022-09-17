using FluentMigrator;
using SerialsOnlineCenter.DAL.Entities;
using System.Data;

namespace SerialsOnlineCenter.DAL.Migrations
{
    [Migration(1109202200000)]
    public class Migration_1109202200000 : Migration
    {
        public override void Up()
        {
            Create.Table("Subscriptions")
                .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(60).NotNullable()
                .WithColumn("PricePerMonth").AsDecimal().NotNullable();

            Create.Table("Users")
                .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("UserName").AsString(50).NotNullable()
                .WithColumn("Email").AsString(60).NotNullable()
                .WithColumn("SubscriptionId").AsInt32().NotNullable().ForeignKey("Subscriptions", "Id");

            Create.Table("Purchases")
                .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("Date").AsDate().NotNullable()
                .WithColumn("AmountOfMonths").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("TotalPrice").AsDecimal().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("Users", "Id")
                .WithColumn("SubscriptionId").AsInt32().NotNullable().ForeignKey("Subscriptions", "Id");

            Create.Table("Genres")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable();

            Create.Table("Serials")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString(60).NotNullable()
                .WithColumn("AmountOfSeries").AsInt32().NotNullable()
                .WithColumn("Description").AsString(1000)
                .WithColumn("ReleaseYear").AsInt32().NotNullable()
                .WithColumn("GenreId").AsInt32().NotNullable().ForeignKey("Genres", "Id");

            Create.Table("Ratings")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Value").AsInt32().NotNullable()
                .WithColumn("Annotation").AsString(1000);

            Create.Table("UsersRatings")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("Users", "Id")
                .WithColumn("RatingId").AsInt32().NotNullable().ForeignKey("Ratings", "Id");

            Create.Table("SerialsRatings")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("SerialId").AsInt32().NotNullable().ForeignKey("Serials", "Id").OnDelete(Rule.Cascade)
                .WithColumn("RatingId").AsInt32().NotNullable().ForeignKey("Ratings", "Id");

            Insert.IntoTable("Subscriptions")
                .Row(new SubscriptionEntity()
                {
                    Id = 1,
                    Name = "Default",
                    PricePerMonth = 10.0M
                })
                .Row(new SubscriptionEntity()
                {
                    Id = 2,
                    Name = "Family",
                    PricePerMonth = 25.0M
                })
                .Row(new SubscriptionEntity()
                {
                    Id = 3,
                    Name = "Extented",
                    PricePerMonth = 34.0M
                })
                .Row(new SubscriptionEntity()
                {
                    Id = 4,
                    Name = "Premium",
                    PricePerMonth = 46.6M
                });
        }

        public override void Down()
        {
            Delete.Table("Genres");
            Delete.Table("Purchases");
            Delete.Table("Ratings");
            Delete.Table("Serials");
            Delete.Table("Users");
            Delete.Table("Subscriptions");
            Delete.Table("UsersRatings");
            Delete.Table("SerialsRatings");
        }
    }
}
