using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class chrRaceMap : EntityTypeConfiguration<chrRace>
    {
        public chrRaceMap()
        {
            // Primary Key
            this.HasKey(t => t.raceID);

            // Properties
            this.Property(t => t.raceName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            this.Property(t => t.shortDescription)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("chrRaces");
            this.Property(t => t.raceID).HasColumnName("raceID");
            this.Property(t => t.raceName).HasColumnName("raceName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.shortDescription).HasColumnName("shortDescription");
        }
    }
}
