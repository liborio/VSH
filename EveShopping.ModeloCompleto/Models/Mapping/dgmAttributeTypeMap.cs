using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class dgmAttributeTypeMap : EntityTypeConfiguration<dgmAttributeType>
    {
        public dgmAttributeTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.attributeID);

            // Properties
            this.Property(t => t.attributeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.attributeName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            this.Property(t => t.displayName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("dgmAttributeTypes");
            this.Property(t => t.attributeID).HasColumnName("attributeID");
            this.Property(t => t.attributeName).HasColumnName("attributeName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.defaultValue).HasColumnName("defaultValue");
            this.Property(t => t.published).HasColumnName("published");
            this.Property(t => t.displayName).HasColumnName("displayName");
            this.Property(t => t.unitID).HasColumnName("unitID");
            this.Property(t => t.stackable).HasColumnName("stackable");
            this.Property(t => t.highIsGood).HasColumnName("highIsGood");
            this.Property(t => t.categoryID).HasColumnName("categoryID");
        }
    }
}
