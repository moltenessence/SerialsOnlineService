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
                    genre = "Fantasy",
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
                })
                 .Row(new
                 {
                     serial_id = 4,
                     name = "Friends",
                     amount_of_series = 236,
                     description = "The lives of twenty-something friends in New York City, each with their own dreams and drives: Joey a struggling actor, " +
                     "Monica a chef, Rachel a waitress who hopes to work in fashion, Ross a paleontologist, " +
                     "Chandler who hates his job in data processing, and Phoebe a masseuse/musician",
                     release_year = 1994,
                     genre = "Drama",
                     subscription_id = 3
                 })
                  .Row(new
                  {
                      serial_id = 5,
                      name = "Attack on Titans",
                      amount_of_series = 87,
                      description = "Set in a post-apocalyptic world where the remains of humanity live behind walls protecting them from giant humanoid Titans, " +
                      "Attack on Titan follows protagonist Eren Jaeger, along with friends Mikasa Ackerman and Armin Arlert. When a Colossal Titan breaches the wall of their hometown," +
                      " Titans destroy the city and eat Eren's mother.",
                      release_year = 2013,
                      genre = "Anime",
                      subscription_id = 4
                  })
                .Row(new
                {
                    serial_id = 6,
                    name = "Stranger things",
                    amount_of_series = 32,
                    description = "American science fiction horror drama television series created by the Duffer Brothers, who also serve as showrunners and are executive producers along " +
                    "with Shawn Levy and Dan Cohen. Produced by Monkey Massacre Productions and Levy's 21 Laps Entertainment, " +
                    "the first season was released on Netflix on July 15, 2016. Its second, third, and fourth seasons followed in October 2017, July 2019, " +
                    "and May and July 2022, respectively. In February 2022, the series was renewed for a fifth and final season.",
                    release_year = 2016,
                    genre = "Drama",
                    subscription_id = 1
                });

        }

        public override void Down()
        {
        }
    }
}
