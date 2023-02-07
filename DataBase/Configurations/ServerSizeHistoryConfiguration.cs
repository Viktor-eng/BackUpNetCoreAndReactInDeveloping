using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataBase.Configurations
{
    internal class ServerSizeHistoryConfiguration : IEntityTypeConfiguration<ServerSizeHistory>
    {
        public void Configure(EntityTypeBuilder<ServerSizeHistory> builder)
        {
            builder
                .HasOne(e => e.ServerToDrive)
                .WithMany()
                .HasForeignKey(e => e.ServerToDriveId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}