using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class dgmTypeAttributeMap : EntityTypeConfiguration<dgmTypeAttribute>
    {
        public dgmTypeAttributeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.typeID, t.attributeID });

            // Properties
            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.attributeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("dgmTypeAttributes");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.attributeID).HasColumnName("attributeID");
            this.Property(t => t.valueInt).HasColumnName("valueInt");
            this.Property(t => t.valueFloat).HasColumnName("valueFloat");
        }
    }
}
