using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Contexts.Implementation
{
    public partial class TestContext : BaseDbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Encrypt=False;Database=Test;Integrated Security=false;User ID=admin;Password=pspihp;");
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
