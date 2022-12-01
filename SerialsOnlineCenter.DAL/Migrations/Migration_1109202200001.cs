using FluentMigrator;

namespace SerialsOnlineCenter.DAL.Migrations
{
    [Migration(1109202200001)]
    public class Migration_1109202200001 : Migration
    {
        public override void Up()
        {
            var defaultSubscription = new
            {
                subscription_id = 1,
                name = "Default",
                price_per_month = 10.0M
            };

            var familySubscription = new
            {
                subscription_id = 2,
                name = "Family",
                price_per_month = 25.0M
            };

            var extentedSubscription = new
            {
                subscription_id = 3,
                name = "Extented",
                price_per_month = 34.0M
            };

            var premiumSubscription = new
            {
                subscription_id = 4,
                name = "Premium",
                price_per_month = 50.0M
            };

            Insert.IntoTable("subscriptions")
                .Row(defaultSubscription)
                .Row(familySubscription)
                .Row(extentedSubscription)
                .Row(premiumSubscription);

            Insert.IntoTable("serials")
                .Row(new
                {
                    serial_id = 1,
                    name = "Game Of Thrones",
                    amount_of_series = 73,
                    description = "In the Game of Thrones, you either win or you die. In the mythical continent of Westeros, nine families of higher nobility " +
                      "(Targaryen, Lannisters, Starks, Tyrell, Martell, Greyjoys, Baratheons and Boltons) scramble bitterly to gain " +
                      "power over the seven kingdoms and the Iron throne.",
                    release_year = 2011,
                    genre = "Drama, Fantasy",
                    subscription_id = 1
                })
                .Row(new
                {
                    serial_id = 2,
                    name = "Pet's adventures",
                    amount_of_series = 18,
                    description = "Nice story about a funny team pets called SupremeStars.",
                    release_year = 2019,
                    genre = "Adventures",
                    subscription_id = 3
                })
                .Row(new
                {
                    serial_id = 3,
                    name = "Scream IV",
                    amount_of_series = 6,
                    description = "After 10 years, Sidney Prescott returns to Woodsboro for her book tour OUT OF DARKNESS" +
                      " a self help book about life before and after the murders, Dewey is now Sheriff of the town with " +
                      "Deputy Judy Hicks. Since the year 2000 when the murders ended in Hollywood Gale has got writers block as" +
                      " Woodsboro has become boring.",
                    release_year = 2011,
                    genre = "Horror",
                    subscription_id = 2
                });
        }

        public override void Down()
        {
        }
    }
}
