using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmsHub.Persistence.Scaffold;

public partial class SmsHubContext : DbContext
{
    public SmsHubContext()
    {
    }

    public SmsHubContext(DbContextOptions<SmsHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }

    public virtual DbSet<CcSend> CcSends { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<ConfigType> ConfigTypes { get; set; }

    public virtual DbSet<ConfigTypeGroup> ConfigTypeGroups { get; set; }

    public virtual DbSet<Consumer> Consumers { get; set; }

    public virtual DbSet<ConsumerLine> ConsumerLines { get; set; }

    public virtual DbSet<ConsumerSafeIp> ConsumerSafeIps { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactCategory> ContactCategories { get; set; }

    public virtual DbSet<ContactNumber> ContactNumbers { get; set; }

    public virtual DbSet<ContactNumberCategory> ContactNumberCategories { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<DeepLog> DeepLogs { get; set; }

    public virtual DbSet<DisallowedPhrase> DisallowedPhrases { get; set; }

    public virtual DbSet<Hash> Hashes { get; set; }

    public virtual DbSet<InformativeLog> InformativeLogs { get; set; }

    public virtual DbSet<InvalidLoginReason> InvalidLoginReasons { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobParameter> JobParameters { get; set; }

    public virtual DbSet<JobQueue> JobQueues { get; set; }

    public virtual DbSet<Line> Lines { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<LogLevel> LogLevels { get; set; }

    public virtual DbSet<LogoutReason> LogoutReasons { get; set; }

    public virtual DbSet<MessageBatch> MessageBatches { get; set; }

    public virtual DbSet<MessageState> MessageStates { get; set; }

    public virtual DbSet<MessageStateCategory> MessageStateCategories { get; set; }

    public virtual DbSet<MessagesDetail> MessagesDetails { get; set; }

    public virtual DbSet<MessagesHolder> MessagesHolders { get; set; }

    public virtual DbSet<OperationType> OperationTypes { get; set; }

    public virtual DbSet<PermittedTime> PermittedTimes { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<ProviderResponseStatus> ProviderResponseStatuses { get; set; }

    public virtual DbSet<Received> Receiveds { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schema> Schemas { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<ServerUser> ServerUsers { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    public virtual DbSet<TemplateCategory> TemplateCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    public virtual DbSet<VersionInfo> VersionInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Encrypt=False;Database=SmsHub;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AggregatedCounter>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK_HangFire_CounterAggregated");

            entity.ToTable("AggregatedCounter", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CcSend>(entity =>
        {
            entity.ToTable("CcSend");

            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.ConfigTypeGroup).WithMany(p => p.CcSends)
                .HasForeignKey(d => d.ConfigTypeGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigTypeGroup_REFERS_CcSend_Id");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.ToTable("Config");

            entity.HasOne(d => d.ConfigTypeGroup).WithMany(p => p.Configs)
                .HasForeignKey(d => d.ConfigTypeGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigTypeGroup_REFERS_Config_ConfigTypeGroupId");

            entity.HasOne(d => d.Template).WithMany(p => p.Configs)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Template_REFERS_Config_TemplateId");
        });

        modelBuilder.Entity<ConfigType>(entity =>
        {
            entity.ToTable("ConfigType");

            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<ConfigTypeGroup>(entity =>
        {
            entity.ToTable("ConfigTypeGroup");

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.ConfigType).WithMany(p => p.ConfigTypeGroups)
                .HasForeignKey(d => d.ConfigTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigType_REFERS_ConfigTypeGroup_Id");
        });

        modelBuilder.Entity<Consumer>(entity =>
        {
            entity.ToTable("Consumer");

            entity.Property(e => e.Description).HasMaxLength(1023);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<ConsumerLine>(entity =>
        {
            entity.ToTable("ConsumerLine");

            entity.HasOne(d => d.Consumer).WithMany(p => p.ConsumerLines)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consumer_REFERS_ConsumerLine_ConsumerId");

            entity.HasOne(d => d.Line).WithMany(p => p.ConsumerLines)
                .HasForeignKey(d => d.LineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Line_REFERS_ConsumerLine_LineId");
        });

        modelBuilder.Entity<ConsumerSafeIp>(entity =>
        {
            entity.ToTable("ConsumerSafeIp");

            entity.Property(e => e.FromIp).HasMaxLength(64);
            entity.Property(e => e.ToIp).HasMaxLength(64);

            entity.HasOne(d => d.Consumer).WithMany(p => p.ConsumerSafeIps)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consumer_REFERS_ConsumerSafeIp_ConsumerId");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact");

            entity.HasIndex(e => e.Title, "UQ_Contact_Title").IsUnique();

            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<ContactCategory>(entity =>
        {
            entity.ToTable("ContactCategory");

            entity.Property(e => e.Css).HasMaxLength(1023);
            entity.Property(e => e.Description).HasMaxLength(1023);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<ContactNumber>(entity =>
        {
            entity.ToTable("ContactNumber");

            entity.Property(e => e.Number).HasMaxLength(255);

            entity.HasOne(d => d.ContactCategory).WithMany(p => p.ContactNumbers)
                .HasForeignKey(d => d.ContactCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactCategory_REFERS_ContactNumber_ContactCategoryId");

            entity.HasOne(d => d.ContactNumberCategory).WithMany(p => p.ContactNumbers)
                .HasForeignKey(d => d.ContactNumberCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactNumberCategory_REFERS_ContactNumber_ContactNumberCategoryId");
        });

        modelBuilder.Entity<ContactNumberCategory>(entity =>
        {
            entity.ToTable("ContactNumberCategory");

            entity.HasIndex(e => e.Title, "UQ_ContactNumberCategory_Title").IsUnique();

            entity.Property(e => e.Css).HasMaxLength(1023);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_Counter");

            entity.ToTable("Counter", "HangFire");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<DeepLog>(entity =>
        {
            entity.ToTable("DeepLog");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryDb).HasMaxLength(255);
            entity.Property(e => e.PrimaryId).HasMaxLength(63);
            entity.Property(e => e.PrimaryTable).HasMaxLength(255);

            entity.HasOne(d => d.OperationType).WithMany(p => p.DeepLogs)
                .HasForeignKey(d => d.OperationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OperationType_REFERS_DeepLog_OperationTypeId");
        });

        modelBuilder.Entity<DisallowedPhrase>(entity =>
        {
            entity.ToTable("DisallowedPhrase");

            entity.Property(e => e.Phrase).HasMaxLength(255);

            entity.HasOne(d => d.ConfigTypeGroup).WithMany(p => p.DisallowedPhrases)
                .HasForeignKey(d => d.ConfigTypeGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigTypeGroup_REFERS_DisallowedPhrase_Id");
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Field }).HasName("PK_HangFire_Hash");

            entity.ToTable("Hash", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Field).HasMaxLength(100);
        });

        modelBuilder.Entity<InformativeLog>(entity =>
        {
            entity.ToTable("InformativeLog");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Section).HasMaxLength(255);
            entity.Property(e => e.UserInfo).HasMaxLength(255);

            entity.HasOne(d => d.LogLevel).WithMany(p => p.InformativeLogs)
                .HasForeignKey(d => d.LogLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogLevel_REFERS_InformativeLog_Id");
        });

        modelBuilder.Entity<InvalidLoginReason>(entity =>
        {
            entity.ToTable("InvalidLoginReason");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Job");

            entity.ToTable("Job", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName").HasFilter("([StateName] IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.StateName).HasMaxLength(20);
        });

        modelBuilder.Entity<JobParameter>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Name }).HasName("PK_HangFire_JobParameter");

            entity.ToTable("JobParameter", "HangFire");

            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.Job).WithMany(p => p.JobParameters)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_JobParameter_Job");
        });

        modelBuilder.Entity<JobQueue>(entity =>
        {
            entity.HasKey(e => new { e.Queue, e.Id }).HasName("PK_HangFire_JobQueue");

            entity.ToTable("JobQueue", "HangFire");

            entity.Property(e => e.Queue).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FetchedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Line>(entity =>
        {
            entity.ToTable("Line");

            entity.HasIndex(e => e.Number, "UQ_Line_Number").IsUnique();

            entity.Property(e => e.Number).HasMaxLength(15);

            entity.HasOne(d => d.Provider).WithMany(p => p.Lines)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provider_REFERS_Line_ProviderId");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_List");

            entity.ToTable("List", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<LogLevel>(entity =>
        {
            entity.ToTable("LogLevel");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Css).HasMaxLength(1023);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<LogoutReason>(entity =>
        {
            entity.ToTable("LogoutReason");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<MessageBatch>(entity =>
        {
            entity.ToTable("MessageBatch");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Line).WithMany(p => p.MessageBatches)
                .HasForeignKey(d => d.LineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageBatch_REFERS_Line_MessageBatchId");
        });

        modelBuilder.Entity<MessageState>(entity =>
        {
            entity.ToTable("MessageState");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MessageStateCategory).WithMany(p => p.MessageStates)
                .HasForeignKey(d => d.MessageStateCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageStateCategory_REFERS_MessageState_MessageStateCategoryId");

            entity.HasOne(d => d.MessagesDetail).WithMany(p => p.MessageStates)
                .HasForeignKey(d => d.MessagesDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessagesDetail_REFERS_MessageState_MessagesDetailId");
        });

        modelBuilder.Entity<MessageStateCategory>(entity =>
        {
            entity.ToTable("MessageStateCategory");

            entity.Property(e => e.Css).HasMaxLength(1023);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Provider).WithMany(p => p.MessageStateCategories)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provider_REFERS_MessageStateCategory_ProviderId");
        });

        modelBuilder.Entity<MessagesDetail>(entity =>
        {
            entity.ToTable("MessagesDetail");

            entity.Property(e => e.Receptor).HasMaxLength(15);
            entity.Property(e => e.SendDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MessagesHolder).WithMany(p => p.MessagesDetails)
                .HasForeignKey(d => d.MessagesHolderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessagesHolder_REFERS_MessagesDetail_MessagesHolderId");
        });

        modelBuilder.Entity<MessagesHolder>(entity =>
        {
            entity.ToTable("MessagesHolder");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MessageBatch).WithMany(p => p.MessagesHolders)
                .HasForeignKey(d => d.MessageBatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageBatch_REFERS_MessagesHolder_MessageBatchId");
        });

        modelBuilder.Entity<OperationType>(entity =>
        {
            entity.ToTable("OperationType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Css).HasMaxLength(1023);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<PermittedTime>(entity =>
        {
            entity.ToTable("PermittedTime");

            entity.Property(e => e.FromTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ToTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.ConfigTypeGroup).WithMany(p => p.PermittedTimes)
                .HasForeignKey(d => d.ConfigTypeGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfigTypeGroup_REFERS_PermittedTime_ConfigTypeGroupId");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.ToTable("Provider");

            entity.HasIndex(e => e.Title, "UQ_Provider_Title").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BaseUri).HasMaxLength(255);
            entity.Property(e => e.CredentialTemplate)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DefaultPreNumber).HasMaxLength(15);
            entity.Property(e => e.FallbackBaseUri).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Website).HasMaxLength(255);
        });

        modelBuilder.Entity<ProviderResponseStatus>(entity =>
        {
            entity.ToTable("ProviderResponseStatus");
        });

        modelBuilder.Entity<Received>(entity =>
        {
            entity.ToTable("Received");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.ReceiveDateTime).HasColumnType("datetime");
            entity.Property(e => e.Receptor).HasMaxLength(15);
            entity.Property(e => e.Sender).HasMaxLength(15);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Schema>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK_HangFire_Schema");

            entity.ToTable("Schema", "HangFire");

            entity.Property(e => e.Version).ValueGeneratedNever();
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Server");

            entity.ToTable("Server", "HangFire");

            entity.HasIndex(e => e.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

            entity.Property(e => e.Id).HasMaxLength(200);
            entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
        });

        modelBuilder.Entity<ServerUser>(entity =>
        {
            entity.ToTable("ServerUser");

            entity.Property(e => e.ApiKeyHash)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.DeleteDateTime).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Value }).HasName("PK_HangFire_Set");

            entity.ToTable("Set", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => new { e.Key, e.Score }, "IX_HangFire_Set_Score");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Value).HasMaxLength(256);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Id }).HasName("PK_HangFire_State");

            entity.ToTable("State", "HangFire");

            entity.HasIndex(e => e.CreatedAt, "IX_HangFire_State_CreatedAt");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Reason).HasMaxLength(100);

            entity.HasOne(d => d.Job).WithMany(p => p.States)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_State_Job");
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.ToTable("Template");

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.TemplateCategory).WithMany(p => p.Templates)
                .HasForeignKey(d => d.TemplateCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemplateCategory_REFERS_Template_TemplateCategoryId");
        });

        modelBuilder.Entity<TemplateCategory>(entity =>
        {
            entity.ToTable("TemplateCategory");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ_User_Username").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DisplayName).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.LatestLoginDateTime).HasColumnType("datetime");
            entity.Property(e => e.LockTimespan).HasColumnType("datetime");
            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.RemoveLogInfo).HasMaxLength(255);
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(255);

            entity.HasOne(d => d.Previous).WithMany(p => p.InversePrevious)
                .HasForeignKey(d => d.PreviousId)
                .HasConstraintName("FK_User_REFERS_User_PreviousId");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.ToTable("UserLogin");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AppVersion).HasMaxLength(15);
            entity.Property(e => e.FirstStepDateTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.LogInfo).IsUnicode(false);
            entity.Property(e => e.LogoutDateTime).HasColumnType("datetime");
            entity.Property(e => e.TwoStepCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TwoStepExpireDateTime).HasColumnType("datetime");
            entity.Property(e => e.TwoStepInsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(255);
            entity.Property(e => e.WrongPassword).HasMaxLength(1023);

            entity.HasOne(d => d.InvalidLoginReason).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.InvalidLoginReasonId)
                .HasConstraintName("FK_InvalidLoginReason_REFERS_UserLogin_InvalidLoginReasonId");

            entity.HasOne(d => d.LogoutReason).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.LogoutReasonId)
                .HasConstraintName("FK_LogoutReason_REFERS_UserLogin_LogoutReasonId");

            entity.HasOne(d => d.User).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_REFERS_UserLogin_UserId");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.RemoveLogInfo).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_REFERS_UserRole_RoleId");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_REFERS_UserRole_UserId");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.ToTable("UserToken");

            entity.Property(e => e.AccessTokenExpiresDateTime).HasColumnType("datetime");
            entity.Property(e => e.AccessTokenHash).HasMaxLength(1023);
            entity.Property(e => e.RefreshTokenExpiresDateTime).HasColumnType("datetime");
            entity.Property(e => e.RefreshTokenIdHash).HasMaxLength(1023);
            entity.Property(e => e.RefreshTokenIdHashSource).HasMaxLength(1023);

            entity.HasOne(d => d.User).WithMany(p => p.UserTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_REFERS_UserToken_UserId");
        });

        modelBuilder.Entity<VersionInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VersionInfo");

            entity.HasIndex(e => e.Version, "UC_Version")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.AppliedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1024);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
