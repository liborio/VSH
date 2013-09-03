using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class chrBloodlineMap : EntityTypeConfiguration<chrBloodline>
    {
        public chrBloodlineMap()
        {
            // Primary Key
            this.HasKey(t => t.bloodlineID);

            // Properties
            this.Property(t => t.bloodlineName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            this.Property(t => t.maleDescription)
                .HasMaxLength(1000);

            this.Property(t => t.femaleDescription)
                .HasMaxLength(1000);

            this.Property(t => t.shortDescription)
                .HasMaxLength(500);

            this.Property(t => t.shortMaleDescription)
                .HasMaxLength(500);

            this.Property(t => t.shortFemaleDescription)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("chrBloodlines");
            this.Property(t => t.bloodlineID).HasColumnName("bloodlineID");
            this.Property(t => t.bloodlineName).HasColumnName("bloodlineName");
            this.Property(t => t.raceID).HasColumnName("raceID");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.maleDescription).HasColumnName("maleDescription");
            this.Property(t => t.femaleDescription).HasColumnName("femaleDescription");
            this.Property(t => t.shipTypeID).HasColumnName("shipTypeID");
            this.Property(t => t.corporationID).HasColumnName("corporationID");
            this.Property(t => t.perception).HasColumnName("perception");
            this.Property(t => t.willpower).HasColumnName("willpower");
            this.Property(t => t.charisma).HasColumnName("charisma");
            this.Property(t => t.memory).HasColumnName("memory");
            this.Property(t => t.intelligence).HasColumnName("intelligence");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.shortDescription).HasColumnName("shortDescription");
            this.Property(t => t.shortMaleDescription).HasColumnName("shortMaleDescription");
            this.Property(t => t.shortFemaleDescription).HasColumnName("shortFemaleDescription");
        }
    }
}
