using FluentMigrator;

namespace SmsHub.Persistence.Migrations
{
    [Migration(1403061501)]
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

        private void CreateProviders()
        {
            string Providers=nameof(Providers);
            Create.Table(Providers)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Title").AsString().Unique($"Unique_{Providers}");
                //.ForeignKey
        }
    }
}
