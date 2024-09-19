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
        int _255 = 255, _1023 = 1023;
        public override void Up()
        {
            var methods =
               GetType()
              .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
              .Where(m => m.Name.StartsWith("Create"))
              .ToList();
            methods.ForEach(m => m.Invoke(this, null));
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
                .WithColumn(Id).AsInt16().PrimaryKey(NamingHelper.Pk(TableName.Provider)).Identity()
                .WithColumn("Title").AsString(_255).Unique(NamingHelper.Uq(TableName.Provider, "Title"))
                .WithColumn("Website").AsString(_255).Nullable()
                .WithColumn("DefaultPreNumber").AsString(15).Nullable()
                .WithColumn("BatchSize").AsInt32()
                .WithColumn("BaseUri").AsString(_255)
                .WithColumn("FallbackBaseUri").AsString(_255);
        }
        private void CreateLine()
        {            
            Create.Table(nameof(TableName.Line))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.Line)).Identity()
                .WithColumn("ProviderId").AsInt16()
                    .ForeignKey(NamingHelper.Fk(TableName.Provider, TableName.Line), nameof(TableName.Provider), Id)
                .WithColumn("Number").AsString(15).Unique(NamingHelper.Uq(TableName.Line,"Number"))
                .WithColumn("CredentialType").AsInt16()
                .WithColumn("Credential").AsString(int.MaxValue);
        }
        private void CreateConsumer()
        {           
            Create.Table(nameof(TableName.Consumer))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.Consumer)).Identity()
                .WithColumn("Title").AsString(_255)
                .WithColumn("Description").AsString(_1023)
                .WithColumn("ApiKey").AsString(int.MaxValue);
        }
        private void CreateConsumerLine()
        {
            Create.Table(nameof(TableName.ConsumerLine))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.ConsumerLine)).Identity()
                .WithColumn($"{TableName.Consumer}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.Consumer, TableName.ConsumerLine), nameof(TableName.Consumer), Id)
                .WithColumn("LineId").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.Line, TableName.ConsumerLine), nameof(TableName.Line), Id);
        }
        private void CreateConsumerSafeIp()
        {
            Create.Table(nameof(TableName.ConsumerSafeIp))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.ConsumerSafeIp)).Identity()
                .WithColumn($"{nameof(TableName.Consumer)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.Consumer,TableName.ConsumerSafeIp),nameof(TableName.Consumer), Id)
                .WithColumn("FromIp").AsString(64)
                .WithColumn("ToIp").AsString(64)
                .WithColumn("IsV6").AsBoolean().WithDefaultValue(false);
        }
        private void CreateContactCategory()
        {
            Create.Table(nameof(TableName.ContactCategory))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.ContactCategory)).Identity()
                .WithColumn("Title").AsString(_255)
                .WithColumn("Description").AsString()
                .WithColumn("Css").AsString(_1023);
        }
        private void CreateContactNumberCategory()
        {
            Create.Table(nameof(TableName.ContactNumberCategory))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.ContactNumberCategory)).Identity()
                .WithColumn("Title").AsString(_255)
                    .Unique(NamingHelper.Uq(TableName.ContactNumberCategory,"Title"))
                .WithColumn("Css").AsString(_1023);
        }
        private void CreateContact()
        {
            Create.Table(nameof(TableName.Contact))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.Contact)).Identity()
                .WithColumn("Title").AsString(_255)
                    .Unique(NamingHelper.Uq(TableName.Contact, "Title"));                 
        }
        private void CreateContactNumber() 
        {
            Create.Table(nameof(TableName.ContactNumber))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.ContactNumber)).Identity()
                .WithColumn("Number").AsString(_255)
                .WithColumn($"{nameof(TableName.ContactCategory)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ContactCategory, TableName.ContactNumber), nameof(TableName.ContactCategory), Id)
                .WithColumn($"{nameof(TableName.ContactNumberCategory)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ContactNumberCategory, TableName.ContactNumber), nameof(TableName.ContactNumberCategory), Id);
        }
        private void CreateTampleCategory()
        {
            Create.Table(nameof(TableName.TemplateCategory))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.TemplateCategory)).Identity()
                .WithColumn("Title").AsString(_255)
                .WithColumn("Description").AsString(_255);
        }
        private void CreateTamplate()
        {
            Create.Table(nameof(TableName.Template))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.Template)).Identity()
                .WithColumn("Title").AsString(_255)
                .WithColumn($"{nameof(TableName.TemplateCategory)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.TemplateCategory, TableName.Template), nameof(TableName.TemplateCategory), Id)
                .WithColumn("IsActive").AsBoolean()
                .WithColumn("Parameters").AsString(int.MaxValue)
                .WithColumn("MinCredit").AsInt32();                    
        }
        private void CreateMessageBatch()
        {
            Create.Table(nameof(TableName.MessageBatch))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.MessageBatch)).Identity()
                .WithColumn("HolerSize").AsInt32()
                .WithColumn("AllSize").AsInt32()
                .WithColumn("InsertDateTime").AsDateTime()
                .WithColumn("LineId").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.MessageBatch, TableName.Line), nameof(TableName.Line), Id);
        }
        private void CreateMessageHolder()
        {
            Create.Table(nameof(TableName.MessagesHolder))
                 .WithColumn(Id).AsGuid().PrimaryKey(NamingHelper.Pk(TableName.MessagesHolder))
                 .WithColumn($"{nameof(TableName.MessageBatch)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.MessageBatch, TableName.MessagesHolder), nameof(TableName.MessageBatch), Id)
                 .WithColumn("InsertDateTime").AsDateTime()
                 .WithColumn("RetryCount").AsInt32()
                 .WithColumn("DetailsSize").AsInt32()
                 .WithColumn("SendDone").AsBoolean();
        }
        private void CreateMessageDetail()
        {
            Create.Table(nameof(TableName.MessagesDetail))
                .WithColumn(Id).AsInt64().PrimaryKey(NamingHelper.Pk(TableName.MessagesDetail)).Identity()
                .WithColumn($"{nameof(TableName.MessagesHolder)}{Id}").AsGuid()
                    .ForeignKey(NamingHelper.Fk(TableName.MessagesHolder, TableName.MessagesDetail), nameof(TableName.MessagesHolder), Id)
                .WithColumn("Receptor").AsString(15)
                .WithColumn("ProviderResult").AsInt64()
                .WithColumn("SendDateTime").AsDateTime()
                .WithColumn("Text").AsString(int.MaxValue)
                .WithColumn("SmsCount").AsInt16();
        }
        private void CreateMessageStateCategory()
        {
            Create.Table(nameof(TableName.MessageStateCategory))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.MessageStateCategory)).Identity()
                .WithColumn("Title").AsString(_255)
                .WithColumn($"{nameof(TableName.Provider)}").AsInt16()
                    .ForeignKey(NamingHelper.Fk(TableName.Provider, TableName.MessageStateCategory), nameof(TableName.Provider), Id)
                .WithColumn("IsError").AsBoolean()
                .WithColumn("Css").AsString(_1023);
        }
        private void CreateMessageState()
        {
            Create.Table(nameof(TableName.MessageState))
                .WithColumn(Id).AsInt64().PrimaryKey(NamingHelper.Pk(TableName.MessageState)).Identity()
                .WithColumn($"{nameof(TableName.MessageStateCategory)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.MessageStateCategory, TableName.MessageState), nameof(TableName.MessageStateCategory), Id)
                .WithColumn($"{nameof(TableName.MessagesDetail)}{Id}").AsInt64()
                    .ForeignKey(NamingHelper.Fk(TableName.MessagesDetail, TableName.MessageState), nameof(TableName.MessagesDetail), Id)
                .WithColumn("InsertDateTime").AsDateTime();
        }
        private void CreateLogLevel()
        {
            Create.Table(nameof(TableName.LogLevel))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.LogLevel))
                .WithColumn("Title").AsString(_255)
                .WithColumn("Css").AsString(_1023);
        }
        private void CreateInformativeLog()
        {
            Create.Table(nameof(TableName.InformativeLog))
                .WithColumn(Id).AsInt64().PrimaryKey(NamingHelper.Pk(TableName.InformativeLog)).Identity()
                .WithColumn($"{nameof(TableName.LogLevel)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.LogLevel, TableName.InformativeLog, Id), nameof(TableName.LogLevel),Id)
                .WithColumn("Section").AsString(_255)
                .WithColumn("Description").AsString(int.MaxValue)
                .WithColumn("UserId").AsGuid().Nullable()
                .WithColumn("UserInfo").AsString(_255).Nullable()
                .WithColumn("Ip").AsAnsiString(64)
                .WithColumn("InsertDateTime").AsDateTime()
                .WithColumn("ClientInfo").AsString(int.MaxValue);
        }
        private void CreateOperationType()
        {
            Create.Table(nameof(TableName.OperationType))
               .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.OperationType))
               .WithColumn("Title").AsString(_255)
               .WithColumn("Css").AsString(_1023);
        }
        private void CreateDeepLog()
        {
            Create.Table(nameof(TableName.DeepLog))
               .WithColumn(Id).AsInt64().PrimaryKey(NamingHelper.Pk(TableName.DeepLog)).Identity()
               .WithColumn($"{nameof(TableName.OperationType)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.OperationType, TableName.DeepLog), nameof(TableName.OperationType), Id)
               .WithColumn("PrimaryDb").AsString(_255)
               .WithColumn("PrimaryTable").AsString(_255)
               .WithColumn("PrimaryId").AsString(63)
               .WithColumn("ValueBefore").AsString(int.MaxValue).Nullable()
               .WithColumn("ValueAfter").AsString(int.MaxValue).Nullable()
               .WithColumn("Ip").AsAnsiString(64)
               .WithColumn("InsertDateTime").AsDateTime()
               .WithColumn("ClientInfo").AsString(int.MaxValue);
        }
        private void CreateConfigType()
        {
            Create.Table(nameof(TableName.ConfigType))
                .WithColumn(Id).AsInt16().PrimaryKey(NamingHelper.Pk(TableName.ConfigType))
                .WithColumn("Title").AsString(_255)
                .WithColumn("Description").AsString(int.MaxValue);
        }
        private void CreateConfigTypeGroup()
        {
            Create.Table(nameof(TableName.ConfigTypeGroup))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.ConfigTypeGroup)).Identity()
                .WithColumn($"{nameof(TableName.ConfigType)}{Id}").AsInt16()
                    .ForeignKey(NamingHelper.Fk(TableName.ConfigType,TableName.ConfigTypeGroup, Id), nameof(TableName.ConfigType),Id)
                .WithColumn("Title").AsString(_255)
                .WithColumn("Description").AsString(int.MaxValue);
        }
        private void CreateDisallowedPhrase()
        {
            Create.Table(nameof(TableName.DisallowedPhrase))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.DisallowedPhrase)).Identity()
                .WithColumn($"{nameof(TableName.ConfigTypeGroup)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ConfigTypeGroup, TableName.DisallowedPhrase, Id), nameof(TableName.ConfigTypeGroup), Id)
                .WithColumn("Phrase").AsString(_255);
        }
        private void CreateCcSend()
        {
            Create.Table(nameof(TableName.CcSend))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.CcSend)).Identity()
                .WithColumn($"{nameof(TableName.ConfigTypeGroup)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ConfigTypeGroup, TableName.CcSend, Id), nameof(TableName.ConfigTypeGroup), Id)
                .WithColumn("Mobile").AsFixedLengthAnsiString(11);
        }
        private void CreatePermittedTime()
        {
            Create.Table(nameof(TableName.PermittedTime))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.PermittedTime)).Identity()
                .WithColumn($"{nameof(TableName.ConfigTypeGroup)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ConfigTypeGroup, TableName.PermittedTime),nameof(TableName.ConfigTypeGroup), Id)
                .WithColumn("FromTime").AsFixedLengthAnsiString(5)
                .WithColumn("ToTime").AsFixedLengthAnsiString(5);
        }
        private void CreateConfig()
        {
            Create.Table(nameof(TableName.Config))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.Config)).Identity()
                .WithColumn($"{nameof(TableName.ConfigTypeGroup)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.ConfigTypeGroup, TableName.Config), nameof(TableName.ConfigTypeGroup), Id)
                .WithColumn($"{nameof(TableName.Template)}{Id}").AsInt32()
                    .ForeignKey(NamingHelper.Fk(TableName.Template, TableName.Config), nameof(TableName.Template), Id);
        }
        private void CreateServerUser()
        {
            Create.Table(nameof(TableName.ServerUser))
                .WithColumn(Id).AsInt32().PrimaryKey(NamingHelper.Pk(TableName.ServerUser)).Identity()
                .WithColumn("Username").AsString(_255)
                .WithColumn("IsAdmin").AsBoolean()
                .WithColumn("CreateDateTime").AsDateTime()
                .WithColumn("DeleteDateTime").AsDateTime().Nullable()
                .WithColumn("ApiKeyHash").AsAnsiString(128);
        }
    }
}