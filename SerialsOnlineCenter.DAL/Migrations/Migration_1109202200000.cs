using FluentMigrator;
using SerialsOnlineCenter.DAL.Entities;

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
                .WithColumn("SerialId").AsInt32().NotNullable().ForeignKey("Serials", "Id")
                .WithColumn("RatingId").AsInt32().NotNullable().ForeignKey("Ratings", "Id");

            Insert.IntoTable("Genres")
                .Row(new GenreEntity() { Id = 1, Name = "Horror" })
                .Row(new GenreEntity() { Id = 2, Name = "Adventures" })
                .Row(new GenreEntity() { Id = 3, Name = "Comedy" })
                .Row(new GenreEntity() { Id = 4, Name = "Drama" })
                .Row(new GenreEntity() { Id = 5, Name = "Tragedy" })
                .Row(new GenreEntity() { Id = 6, Name = "Romance" })
                .Row(new GenreEntity() { Id = 7, Name = "Trailer" })
                .Row(new GenreEntity() { Id = 8, Name = "Militant" })
                .Row(new GenreEntity() { Id = 9, Name = "Mystery" })
                .Row(new GenreEntity() { Id = 10, Name = "Fantasy" });

            Insert.IntoTable("Serials")
                .Row(new SerialEntity()
                {
                    Id = 1,
                    Name = "Game Of Thrones",
                    AmountOfSeries = 73,
                    Description = "In the Game of Thrones, you either win or you die. In the mythical continent of Westeros, nine families of higher nobility " +
                                  "(Targaryen, Lannisters, Starks, Tyrell, Martell, Greyjoys, Baratheons and Boltons) scramble bitterly to gain " +
                                  "power over the seven kingdoms and the Iron throne.",
                    ReleaseYear = 2011,
                    GenreId = 10
                })
                .Row(new SerialEntity()
                {
                    Id = 2,
                    Name = "Pet's adventures",
                    AmountOfSeries = 18,
                    Description = "Nice story about a funny team pets called SupremeStars.",
                    ReleaseYear = 2019,
                    GenreId = 2
                })
                .Row(new SerialEntity()
                {
                    Id = 3,
                    Name = "Scream IV",
                    AmountOfSeries = 6,
                    Description = "After 10 years, Sidney Prescott returns to Woodsboro for her book tour OUT OF DARKNESS" +
                                  " a self help book about life before and after the murders, Dewey is now Sheriff of the town with " +
                                  "Deputy Judy Hicks. Since the year 2000 when the murders ended in Hollywood Gale has got writers block as" +
                                  " Woodsboro has become boring.",
                    ReleaseYear = 2011,
                    GenreId = 1
                });

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
