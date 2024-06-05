using IntegradorIot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegrationIot.Infra.Data.EntityConfiguration
{
    public  class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CommandId).IsRequired();

            builder.HasOne(x => x.Command).WithMany(x => x.Parameters)
                .HasForeignKey(x => x.CommandId).OnDelete(DeleteBehavior.NoAction);

           
        }
    }
}
