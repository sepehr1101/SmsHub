using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Extensions;

namespace SmsHub.Persistence.Contexts.Implementation
{
    public partial class SmsHubContext : BaseDbContext
    {
        public SmsHubContext()
        {
        }

        public SmsHubContext(DbContextOptions<SmsHubContext> options)
            : base(options)
        {
        }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = MigrationRunner.GetConnectionInfo().Item1;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(Provider).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
