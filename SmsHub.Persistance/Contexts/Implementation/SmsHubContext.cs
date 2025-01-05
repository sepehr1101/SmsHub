using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var connectionString = MigrationRunner.GetConnectionInfo().Item1;
                //optionsBuilder.UseSqlServer(connectionString);
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
