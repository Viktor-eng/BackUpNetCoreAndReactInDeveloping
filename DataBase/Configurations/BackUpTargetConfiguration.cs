using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    internal class BackUpTargetConfiguration : IEntityTypeConfiguration<BackUpTarget>
    {
        public void Configure(EntityTypeBuilder<BackUpTarget> builder)
        {
            builder
                .HasOne(e => e.Drive)
                .WithMany()
                .HasForeignKey(e => e.DriveId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.Storage)
                .WithMany()
                .HasForeignKey(e => e.StorageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}