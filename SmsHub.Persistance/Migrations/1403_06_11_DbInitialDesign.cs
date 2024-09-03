using FluentMigrator;

namespace SmsHub.Persistence.Migrations
{
    [Migration(1403061101)]
    internal class DbInitialDesign:Migration
    {
        public override void Up()
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }

        public override void Down()
        {
            Delete.Table("Log");
        }
    }
}
