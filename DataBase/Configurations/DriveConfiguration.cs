using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace DataBase.Configurations
{
    internal class DriveConfiguration : IEntityTypeConfiguration<Drive>
    {
        public void Configure(EntityTypeBuilder<Drive> builder)
        {
            builder.HasData(
            Enumerable.Range(0, 26)
            .Select((c, i) => (new Drive
            {
                Id = i + 1,
                Letter = ((char)(c + 65))
            .ToString()
            }))
            .ToArray());
        }
    }
}
