using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmsHub.Persistence.Models;

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

        public virtual DbSet<Consumer> Consumers { get; set; } = null!;
        public virtual DbSet<ConsumerLine> ConsumerLines { get; set; } = null!;
        public virtual DbSet<ConsumerSafeIp> ConsumerSafeIps { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<ContactCategory> ContactCategories { get; set; } = null!;
        public virtual DbSet<ContactNumber> ContactNumbers { get; set; } = null!;
        public virtual DbSet<ContactNumberCategory> ContactNumberCategories { get; set; } = null!;
        public virtual DbSet<DeepLog> DeepLogs { get; set; } = null!;
        public virtual DbSet<InformativeLog> InformativeLogs { get; set; } = null!;
        public virtual DbSet<Line> Lines { get; set; } = null!;
        public virtual DbSet<LogLevel> LogLevels { get; set; } = null!;
        public virtual DbSet<MessageBatch> MessageBatches { get; set; } = null!;
        public virtual DbSet<MessageState> MessageStates { get; set; } = null!;
        public virtual DbSet<MessageStateCategory> MessageStateCategories { get; set; } = null!;
        public virtual DbSet<MessagesDetail> MessagesDetails { get; set; } = null!;
        public virtual DbSet<MessagesHolder> MessagesHolders { get; set; } = null!;
        public virtual DbSet<OperationType> OperationTypes { get; set; } = null!;
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
            modelBuilder.Entity<Consumer>(entity =>
            {
                entity.ToTable("Consumer");

                entity.Property(e => e.Description).HasMaxLength(1023);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ConsumerLine>(entity =>
            {
                entity.ToTable("ConsumerLine");

                entity.HasOne(d => d.Consumer)
                    .WithMany(p => p.ConsumerLines)
                    .HasForeignKey(d => d.ConsumerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.ConsumerLines)
                    .HasForeignKey(d => d.LineId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ConsumerSafeIp>(entity =>
            {
                entity.ToTable("ConsumerSafeIp");

                entity.Property(e => e.FromIp).HasMaxLength(64);

                entity.Property(e => e.ToIp).HasMaxLength(64);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.HasIndex(e => e.Title, "IX_Unique_Contact_Title")
                    .IsUnique();

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ContactCategory>(entity =>
            {
                entity.ToTable("ContactCategory");

                entity.Property(e => e.Css).HasMaxLength(1023);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ContactNumber>(entity =>
            {
                entity.ToTable("ContactNumber");

                entity.Property(e => e.Number).HasMaxLength(255);

                entity.HasOne(d => d.ContactCategory)
                    .WithMany(p => p.ContactNumbers)
                    .HasForeignKey(d => d.ContactCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ContactNumberCategory)
                    .WithMany(p => p.ContactNumbers)
                    .HasForeignKey(d => d.ContactNumberCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ContactNumberCategory>(entity =>
            {
                entity.ToTable("ContactNumberCategory");

                entity.HasIndex(e => e.Title, "IX_Unique_ContactNumberCategory_Title")
                    .IsUnique();

                entity.Property(e => e.Css).HasMaxLength(1023);

                entity.Property(e => e.Title).HasMaxLength(255);
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

                entity.HasOne(d => d.OperationType)
                    .WithMany(p => p.DeepLogs)
                    .HasForeignKey(d => d.OperationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperationType_OperationType_Id");
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

                entity.HasOne(d => d.LogLevel)
                    .WithMany(p => p.InformativeLogs)
                    .HasForeignKey(d => d.LogLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InformativeLog_LogLevel_Id");
            });

            modelBuilder.Entity<Line>(entity =>
            {
                entity.ToTable("Line");

                entity.HasIndex(e => e.Number, "IX_Unique_Line_Number")
                    .IsUnique();

                entity.Property(e => e.Number).HasMaxLength(15);

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Lines)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LogLevel>(entity =>
            {
                entity.ToTable("LogLevel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Css).HasMaxLength(1023);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<MessageBatch>(entity =>
            {
                entity.ToTable("MessageBatch");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.MessageBatches)
                    .HasForeignKey(d => d.LineId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MessageState>(entity =>
            {
                entity.ToTable("MessageState");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.MessageStateCategory)
                    .WithMany(p => p.MessageStates)
                    .HasForeignKey(d => d.MessageStateCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.MessagesDetailNavigation)
                    .WithMany(p => p.MessageStates)
                    .HasForeignKey(d => d.MessagesDetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageState_MessagesDetail_MessagesDetailId");
            });

            modelBuilder.Entity<MessageStateCategory>(entity =>
            {
                entity.ToTable("MessageStateCategory");

                entity.Property(e => e.Css).HasMaxLength(1023);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.MessageStateCategories)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageStateCategory_Provider_ProviderId");
            });

            modelBuilder.Entity<MessagesDetail>(entity =>
            {
                entity.ToTable("MessagesDetail");

                entity.Property(e => e.Receptor).HasMaxLength(15);

                entity.Property(e => e.SendDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.MessagesHolder)
                    .WithMany(p => p.MessagesDetails)
                    .HasForeignKey(d => d.MessagesHolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MessagesHolder>(entity =>
            {
                entity.ToTable("MessagesHolder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.MessageBatch)
                    .WithMany(p => p.MessagesHolders)
                    .HasForeignKey(d => d.MessageBatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OperationType>(entity =>
            {
                entity.ToTable("OperationType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Css).HasMaxLength(1023);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.HasIndex(e => e.Title, "IX_Unique_Provider_Title")
                    .IsUnique();

                entity.Property(e => e.BaseUri).HasMaxLength(255);

                entity.Property(e => e.DefaultPreNumber).HasMaxLength(15);

                entity.Property(e => e.FallbackBaseUri).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Website).HasMaxLength(255);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("Template");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.TemplateCategory)
                    .WithMany(p => p.Templates)
                    .HasForeignKey(d => d.TemplateCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TemplateCategory>(entity =>
            {
                entity.ToTable("TemplateCategory");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
