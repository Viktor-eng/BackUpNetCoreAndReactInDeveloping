using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    internal class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder
                .HasMany(e=>e.DatabaseDefinitions)
                .WithOne()
                .HasForeignKey(e => e.ServerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(e => e.ServerSizeHistories)
                .WithOne()
                .HasForeignKey(e => e.ServerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
