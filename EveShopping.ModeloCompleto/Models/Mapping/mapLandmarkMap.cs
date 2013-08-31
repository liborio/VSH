using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapLandmarkMap : EntityTypeConfiguration<mapLandmark>
    {
        public mapLandmarkMap()
        {
            // Primary Key
            this.HasKey(t => t.landmarkID);

            // Properties
            this.Property(t => t.landmarkID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.landmarkName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(7000);

            // Table & Column Mappings
            this.ToTable("mapLandmarks");
            this.Property(t => t.landmarkID).HasColumnName("landmarkID");
            this.Property(t => t.landmarkName).HasColumnName("landmarkName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.x).HasColumnName("x");
            this.Property(t => t.y).HasColumnName("y");
            this.Property(t => t.z).HasColumnName("z");
            this.Property(t => t.radius).HasColumnName("radius");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.importance).HasColumnName("importance");
        }
    }
}
