namespace SmsHub.Persistence.Migrations.Enums
{
    internal enum TableName
    {
        Provider,
        Line,
        Consumer,
        ConsumerLine,
        ConsumerSafeIp,
        ContactCategory,
        ContactNumberCategory,
        Contact,
        ContactNumber,
        TemplateCategory,
        Template,
        MessageBatch,
        MessagesHolder,
        MessagesDetail,
        MessageStateCategory,
        MessageState,
        ReceivedHolder,//todo
        ReceivedDetails,//todo
        LogLevel,
        InformativeLog,
        OperationType,
        DeepLog,
        PermittedTime,//todo
        DisallowedPhrase,//todo
        Config//todo
        //todo: cost tables
    }
}
