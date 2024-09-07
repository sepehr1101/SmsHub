using FluentMigrator;
using SmsHub.Persistence.Extensions;
using SmsHub.Persistence.Migrations.Enums;
using System.Reflection;

namespace SmsHub.Persistence.Migrations
{
    [Migration(1403061501)]
    public class DbInitialDesign : Migration
    {
        string Id = nameof(Id);
        public override void Up()
        {
            var methods =
               GetType()
              .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
              .Where(m => m.Name.StartsWith("Create"))
              .ToList();
            methods.ForEach(m => m.Invoke(this, new object[0]));
        }

        public override void Down()
        {
            var tableNames =
              GetType()
             .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
             .Where(m => m.Name.StartsWith("Create"))
             .Select(m=>m.Name.Replace("Create",string.Empty))
             .ToList();
            tableNames.ForEach(t => Delete.Table(t));
        }

        private void CreateProvider()
        {
            Create.Table(nameof(TableName.Provider))
                .WithColumn(Id).AsInt16().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255).Unique(NamingHelper.Unique(TableName.Provider, "Title"))
                .WithColumn("Website").AsString(255).Nullable()
                .WithColumn("DefaultPreNumber").AsString(15).Nullable()
                .WithColumn("BatchSize").AsInt32()
                .WithColumn("BaseUri").AsString(255)
                .WithColumn("FallbackBaseUri").AsString(255);
        }
        private void CreateLine()
        {
            Enum.GetName(typeof(TableName), TableName.OperationType);
            Create.Table(nameof(TableName.Line))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("ProviderId").AsInt16()
                    .ForeignKey(NamingHelper.Fk(TableName.Line, TableName.Provider), nameof(TableName.Provider), Id)
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
                    .ForeignKey(NamingHelper.Fk(TableName.ConsumerLine, TableName.Consumer), nameof(TableName.Consumer), Id)
                .WithColumn("LineId").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ConsumerLine, TableName.Line), nameof(TableName.Line), Id);
        }
        private void CreateConsumerSafeIp()
        {
            Create.Table(nameof(TableName.ConsumerSafeIp))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("FromIp").AsString(64)
                .WithColumn("ToIp").AsString(64)
                .WithColumn("IsV6").AsBoolean().WithDefaultValue(false);
        }
        private void CreateContactCategory()
        {
            Create.Table(nameof(TableName.ContactCategory))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255)
                .WithColumn("Description").AsString()
                .WithColumn("Css").AsString(1023);
        }
        private void CreateContactNumberCategory()
        {
            Create.Table(nameof(TableName.ContactNumberCategory))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255)
                    .Unique(NamingHelper.Unique(TableName.ContactNumberCategory,"Title"))
                .WithColumn("Css").AsString(1023);
        }
        private void CreateContact()
        {
            Create.Table(nameof(TableName.Contact))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255)
                    .Unique(NamingHelper.Unique(TableName.Contact, "Title"));                 
        }
        private void CreateContactNumber() 
        {
            Create.Table(nameof(TableName.ContactNumber))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Number").AsString(255)
                .WithColumn($"{nameof(TableName.ContactCategory)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ContactNumber, TableName.ContactCategory), nameof(TableName.ContactCategory), Id)
                .WithColumn($"{nameof(TableName.ContactNumberCategory)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ContactNumber, TableName.ContactNumberCategory), nameof(TableName.ContactNumberCategory), Id);
        }
        private void CreateTampleCategory()
        {
            Create.Table(nameof(TableName.TemplateCategory))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255)
                .WithColumn("Description").AsString(255);
        }
        private void CreateTamplate()
        {
            Create.Table(nameof(TableName.Template))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255)
                .WithColumn($"{nameof(TableName.TemplateCategory)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.Template, TableName.TemplateCategory), nameof(TableName.TemplateCategory), Id)
                .WithColumn("IsActive").AsBoolean()
                .WithColumn("Parameter5s").AsString();                    
        }
        private void CreateMessageBatch()
        {
            Create.Table(nameof(TableName.MessageBatch))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("HolerSize").AsInt32()
                .WithColumn("AllSize").AsInt32()
                .WithColumn("InsertDateTime").AsDateTime()
                .WithColumn("LineId").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.MessageBatch, TableName.Line), nameof(TableName.Line), Id);
        }
        private void CreateMessageHolder()
        {
            Create.Table(nameof(TableName.MessagesHolder))
                 .WithColumn(Id).AsGuid().PrimaryKey()
                 .WithColumn($"{nameof(TableName.MessageBatch)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.MessagesHolder, TableName.MessageBatch), nameof(TableName.MessageBatch), Id)
                 .WithColumn("InsertDateTime").AsDateTime()
                 .WithColumn("RetryCount").AsInt32()
                 .WithColumn("DetailsSize").AsInt32()
                 .WithColumn("SendDone").AsBoolean();
        }
        private void CreateMessageDetail()
        {
            Create.Table(nameof(TableName.MessagesDetail))
                .WithColumn(Id).AsInt64().PrimaryKey().Identity()
                .WithColumn($"{nameof(TableName.MessagesHolder)}{Id}").AsGuid()
                    .ForeignKey(NamingHelper.Fk(TableName.MessagesDetail, TableName.MessagesHolder), nameof(TableName.MessagesHolder), Id)
                .WithColumn("Receptor").AsString(15)
                .WithColumn("ProviderResult").AsInt64()
                .WithColumn("SendDateTime").AsDateTime()
                .WithColumn("Text").AsString()
                .WithColumn("SmsCount").AsInt16();
        }
        private void CreateMessageStateCategory()
        {
            Create.Table(nameof(TableName.MessageStateCategory))
                .WithColumn(Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(255)
                .WithColumn($"{nameof(TableName.Provider)}").AsInt16()
                    .ForeignKey(NamingHelper.Fk(TableName.MessageStateCategory, TableName.Provider), nameof(TableName.Provider), Id)
                .WithColumn("IsError").AsBoolean()
                .WithColumn("Css").AsString(1023);
        }
        private void CreateMessageState()
        {
            Create.Table(nameof(TableName.MessageState))
                .WithColumn(Id).AsInt64().PrimaryKey().Identity()
                .WithColumn($"{nameof(TableName.MessageStateCategory)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.MessageState, TableName.MessageStateCategory), nameof(TableName.MessageStateCategory), Id)
                .WithColumn($"{nameof(TableName.MessagesDetail)}").AsInt64()
                    .ForeignKey(NamingHelper.Fk(TableName.MessageState, TableName.MessagesDetail), nameof(TableName.MessagesDetail), Id)
                .WithColumn("InsertDateTime").AsDateTime();
        }
    }
}