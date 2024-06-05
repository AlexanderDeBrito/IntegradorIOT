using IntegradorIot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegrationIot.Infra.Data.EntityConfiguration
{
    public class CommandConfiguration : IEntityTypeConfiguration<Commands>
    {
        public void Configure(EntityTypeBuilder<Commands> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CommandDescriptionId).IsRequired();

            builder.HasOne(x => x.CommandDescription).WithOne(x => x.Command).OnDelete(DeleteBehavior.NoAction);    

        }
    }
}
