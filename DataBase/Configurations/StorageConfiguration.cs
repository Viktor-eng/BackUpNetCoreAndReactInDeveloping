using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    internal class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder
                .HasMany(e => e.StorageSizeHistories)
                .WithOne()
                .HasForeignKey(e => e.StorageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}