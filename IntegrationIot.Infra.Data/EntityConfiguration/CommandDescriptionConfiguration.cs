using IntegradorIot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegrationIot.Infra.Data.EntityConfiguration
{
    public class CommandDescriptionConfiguration : IEntityTypeConfiguration<CommandDescription>
    {
        public void Configure(EntityTypeBuilder<CommandDescription> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DeviceId).IsRequired();

            builder.HasOne(x => x.Device).WithMany(x => x.CommandDescriptions)
                .HasForeignKey(x => x.DeviceId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
