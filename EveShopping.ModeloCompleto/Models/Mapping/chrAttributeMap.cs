using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class chrAttributeMap : EntityTypeConfiguration<chrAttribute>
    {
        public chrAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.attributeID);

            // Properties
            this.Property(t => t.attributeName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            this.Property(t => t.shortDescription)
                .HasMaxLength(500);

            this.Property(t => t.notes)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("chrAttributes");
            this.Property(t => t.attributeID).HasColumnName("attributeID");
            this.Property(t => t.attributeName).HasColumnName("attributeName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.shortDescription).HasColumnName("shortDescription");
            this.Property(t => t.notes).HasColumnName("notes");
        }
    }
}
