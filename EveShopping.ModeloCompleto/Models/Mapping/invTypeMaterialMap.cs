using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class invTypeMaterialMap : EntityTypeConfiguration<invTypeMaterial>
    {
        public invTypeMaterialMap()
        {
            // Primary Key
            this.HasKey(t => new { t.typeID, t.materialTypeID });

            // Properties
            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.materialTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("invTypeMaterials");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.materialTypeID).HasColumnName("materialTypeID");
            this.Property(t => t.quantity).HasColumnName("quantity");
        }
    }
}
