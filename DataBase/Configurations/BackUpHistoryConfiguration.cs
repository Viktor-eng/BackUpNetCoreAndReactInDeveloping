using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    internal class BackUpHistoryConfiguration : IEntityTypeConfiguration<BackUpHistory>
    {
        public void Configure(EntityTypeBuilder<BackUpHistory> builder)
        {
            builder
                .HasMany(e => e.BackUpHistoryLogs)
                .WithOne()
                .HasForeignKey(e => e.BackUpHistoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
