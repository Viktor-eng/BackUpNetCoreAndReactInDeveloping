using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    internal class DatabaseDefinitionConfiguration : IEntityTypeConfiguration<DatabaseDefinition>
    {
        public void Configure(EntityTypeBuilder<DatabaseDefinition> builder)
        {
            builder
                .HasMany(e => e.BackUpTargets)
                .WithOne()
                .HasForeignKey(e => e.DatabaseDefinitionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(e => e.BackUpHistories)
                .WithOne()
                .HasForeignKey(e => e.DatabaseDefinitionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(e => e.ScheduleBackups)
                .WithOne()
                .HasForeignKey(e => e.DatabaseDefinitionId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
