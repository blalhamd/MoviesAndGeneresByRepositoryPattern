
using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiddleLayer.ConfigurationEntities
{
    public class GenereConfiguration : IEntityTypeConfiguration<Genere>
    {
        public void Configure(EntityTypeBuilder<Genere> builder)
        {
            builder.ToTable("Generes").HasKey(e => e.Id);

            builder.Property(e => e.Name).HasColumnType("varchar").HasMaxLength(250).IsRequired();



        }
    }
}
