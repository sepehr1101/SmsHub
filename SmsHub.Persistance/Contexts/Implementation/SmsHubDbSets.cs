using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Receiving.Entities;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Domain.Features.Sending.Entities;

namespace SmsHub.Persistence.Contexts.Implementation
{
    public partial class SmsHubContext
    {
        public virtual DbSet<CcSend> CcSends { get; set; } = null!;
        public virtual DbSet<Config> Configs { get; set; } = null!;
        public virtual DbSet<ConfigType> ConfigTypes { get; set; } = null!;
        public virtual DbSet<ConfigTypeGroup> ConfigTypeGroups { get; set; } = null!;
        public virtual DbSet<Consumer> Consumers { get; set; } = null!;
        public virtual DbSet<ConsumerLine> ConsumerLines { get; set; } = null!;
        public virtual DbSet<ConsumerSafeIp> ConsumerSafeIps { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<ContactCategory> ContactCategories { get; set; } = null!;
        public virtual DbSet<ContactNumber> ContactNumbers { get; set; } = null!;
        public virtual DbSet<ContactNumberCategory> ContactNumberCategories { get; set; } = null!;
        public virtual DbSet<DeepLog> DeepLogs { get; set; } = null!;
        public virtual DbSet<DisallowedPhrase> DisallowedPhrases { get; set; } = null!;
        public virtual DbSet<InformativeLog> InformativeLogs { get; set; } = null!;
        public virtual DbSet<Line> Lines { get; set; } = null!;
        public virtual DbSet<LogLevel> LogLevels { get; set; } = null!;
        public virtual DbSet<MessageBatch> MessageBatches { get; set; } = null!;
        public virtual DbSet<MessageState> MessageStates { get; set; } = null!;
        public virtual DbSet<MessageStateCategory> MessageStateCategories { get; set; } = null!;
        public virtual DbSet<MessagesDetail> MessagesDetails { get; set; } = null!;
        public virtual DbSet<MessagesHolder> MessagesHolders { get; set; } = null!;
        public virtual DbSet<OperationType> OperationTypes { get; set; } = null!;
        public virtual DbSet<PermittedTime> PermittedTimes { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<Template> Templates { get; set; } = null!;
        public virtual DbSet<TemplateCategory> TemplateCategories { get; set; } = null!;
        public virtual DbSet<ServerUser> ServerUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<Received> Receiveds{ get; set; }
        public virtual DbSet<ProviderResponseStatus> ProviderResponseStatuses { get; set; } 
    }
}
