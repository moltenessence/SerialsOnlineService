using FluentMigrator;


namespace SerialsOnlineCenter.DAL.Migrations
{
    [Migration(1109202200001)]
    public class Migration_1109202200001 : Migration
    {
        public override void Up()
        {
            Create.Column("SubscriptionId")
                .OnTable("Serials")
                .AsInt32()
                .NotNullable()
                .WithDefaultValue(1)
                .ForeignKey("Subscriptions", "Id");
        }

        public override void Down()
        {
            Delete.Column("GenreId").FromTable("Genres");
        }
    }
}
