using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class chrAncestryMap : EntityTypeConfiguration<chrAncestry>
    {
        public chrAncestryMap()
        {
            // Primary Key
            this.HasKey(t => t.ancestryID);

            // Properties
            this.Property(t => t.ancestryName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            this.Property(t => t.shortDescription)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("chrAncestries");
            this.Property(t => t.ancestryID).HasColumnName("ancestryID");
            this.Property(t => t.ancestryName).HasColumnName("ancestryName");
            this.Property(t => t.bloodlineID).HasColumnName("bloodlineID");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.perception).HasColumnName("perception");
            this.Property(t => t.willpower).HasColumnName("willpower");
            this.Property(t => t.charisma).HasColumnName("charisma");
            this.Property(t => t.memory).HasColumnName("memory");
            this.Property(t => t.intelligence).HasColumnName("intelligence");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.shortDescription).HasColumnName("shortDescription");
        }
    }
}
