
using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiddleLayer.ConfigurationEntities
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            builder.ToTable("Movies").HasKey(x => x.Id);

            builder.Property(x => x.Title).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(x => x.year).IsRequired();
            builder.Property(x => x.Rate).HasColumnType("float").IsRequired();
            builder.Property(x => x.StoreLine).HasColumnType("varchar").HasMaxLength(250).IsRequired();




            builder.HasOne(x => x.genere)
                   .WithMany(x => x.Movies)
                   .HasForeignKey(x => x.genereId)
                   .IsRequired();
        }

    }
}
