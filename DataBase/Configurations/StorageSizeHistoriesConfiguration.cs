using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataBase.Configurations
{
    internal class StorageSizeHistoriesConfiguration : IEntityTypeConfiguration<StorageSizeHistory>
    {
        public void Configure(EntityTypeBuilder<StorageSizeHistory> builder)
        {
            builder
                .HasOne(e => e.StorageToDrive)
                .WithMany()
                .HasForeignKey(e => e.StorageToDriveId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}