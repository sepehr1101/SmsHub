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
        PermittedTimeGroup,
        PermittedTime,
        DisallowedPhraseGroup,
        DisallowedPhrase,
        CcSendGroup,
        CcSend,
        Config//todo
        //todo: cost tables
    }
}
