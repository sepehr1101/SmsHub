﻿namespace SmsHub.Persistence.Migrations.Enums
{
    internal enum TableName
    {
        User,
        UserLogin,
        Role,
        UserRole,
        UserToken,
        InvalidLoginReason,
        LogoutReason,
        Provider,
        Line,
        UserLine,
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
        MessageDetailStatus,
        MessageStateCategory,
        MessageState,
        Received,
        ReceivedHolder,//todo
        ReceivedDetails,//todo
        LogLevel,
        InformativeLog,
        OperationType,
        DeepLog,
        ConfigType,
        ConfigTypeGroup,
        PermittedTime,
        DisallowedPhrase,
        CcSend,
        Config,//todo
        //todo: cost tables
        ServerUser,
        ProviderResponseStatus
    }
}
