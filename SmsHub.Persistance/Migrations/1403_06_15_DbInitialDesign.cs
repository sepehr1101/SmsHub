using FluentMigrator;

namespace SmsHub.Persistence.Migrations
{
    [Migration(1403061501)]
    internal class DbInitialDesign : Migration
    {
        string Id = nameof(Id);
        public override void Up()
        {
            CreateProvider();
            //todo add all tables
        }

        public override void Down()
        {
            //todo: delete all tables in here
            //Delete.Table("Log");
        }

        private void CreateProvider()
        {           
            Create.Table(nameof(TableName.Provider))
                .WithColumn(Id).AsInt16().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255).Unique(NamingHelper.Unique(TableName.Provider,"Title"))
                .WithColumn("Website").AsString(255).Nullable()
                .WithColumn("DefaultPreNumber").AsString(15).Nullable();
        }
        private void CreateLines()
        {           
            Create.Table(nameof(TableName.Line))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("ProviderId").AsInt16()
                    .ForeignKey(NamingHelper.Fk(TableName.Line, TableName.Provider), nameof(TableName.Provider), $"{nameof(TableName.Provider)}{Id}")
                .WithColumn("Number").AsString(15).Unique(NamingHelper.Unique(TableName.Line,"Number"))
                .WithColumn("CredentialType").AsInt16()
                .WithColumn("Credential").AsString();
        }
        private void CreateConsumer()
        {           
            Create.Table(nameof(TableName.Consumer))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255)
                .WithColumn("Description").AsString(1023)
                .WithColumn("ApiKey").AsString();
        }
        private void CreateConsumerLine()
        {
            Create.Table(nameof(TableName.ConsumerLine))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("ConsumerId").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ConsumerLine, TableName.Consumer), nameof(TableName.Consumer), $"{nameof(TableName.Consumer)}{Id}")
                .WithColumn("LineId").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ConsumerLine, TableName.Line), nameof(TableName.Line), $"{nameof(TableName.Line)}{Id}");
        }
        private void CreateConsumerSafeIp()
        {
            Create.Table(nameof(TableName.ConsumerSafeIp))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("FromIp").AsString(64)
                .WithColumn("ToIp").AsString(64)
                .WithColumn("IsV6").AsBoolean().WithDefaultValue(false);
        }
    }
}
