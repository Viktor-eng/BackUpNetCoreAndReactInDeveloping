using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataBase.Configurations
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        public DbSet<BackUpHistory> BackUpHistories { get; set; }

        public DbSet<BackUpTarget> BackUpTargets { get; set; }

        public DbSet<BackUpHistoryLogs> BackUpHistoryLogs { get; set; }

        public DbSet<DatabaseDefinition> DatabaseDefinitions { get; set; }

        public DbSet<Server> Servers { get; set; }

        public DbSet<ServerSizeHistory> ServerSizeHistories { get; set; }

        public DbSet<ScheduleBackup> ScheduleBackups { get; set; }

        public DbSet<Storage> Storages { get; set; }

        public DbSet<StorageSizeHistory> StorageSizeHistories { get; set; }

        public DbSet<Drive> Drives { get; set; }

        public DbSet<ServerToDrive> ServerToDrives { get; set; }

        public DbSet<StorageToDrive> StorageToDrives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServerConfiguration());
            modelBuilder.ApplyConfiguration(new DatabaseDefinitionConfiguration());
            modelBuilder.ApplyConfiguration(new BackUpHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new StorageConfiguration());
            modelBuilder.ApplyConfiguration(new BackUpTargetConfiguration());
            modelBuilder.ApplyConfiguration(new ServerSizeHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new StorageSizeHistoriesConfiguration());
            modelBuilder.ApplyConfiguration(new DriveConfiguration());
        }
    }
}
