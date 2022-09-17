using FluentMigrator;
using SerialsOnlineCenter.DAL.Entities;


namespace SerialsOnlineCenter.DAL.Migrations
{
    [Migration(1709202200000)]
    public class Migration_1709202200000 : Migration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_Serials_GenreId_Genres_Id").OnTable("Serials");
            Delete.Column("GenreId").FromTable("Serials");

            Create.Column("Genre").OnTable("Serials").AsString(300).NotNullable();

            Delete.Table("Genres");

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
                    Genre = "Drama, Fantasy",
                    SubscriptionId = 1
                })
                .Row(new SerialEntity()
                {
                    Id = 2,
                    Name = "Pet's adventures",
                    AmountOfSeries = 18,
                    Description = "Nice story about a funny team pets called SupremeStars.",
                    ReleaseYear = 2019,
                    Genre = "Adventures",
                    SubscriptionId = 3
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
                    Genre = "Horror",
                    SubscriptionId = 2
                });
        }

        public override void Down()
        {

        }
    }
}
