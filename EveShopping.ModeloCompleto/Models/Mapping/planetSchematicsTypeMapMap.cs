using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class planetSchematicsTypeMapMap : EntityTypeConfiguration<planetSchematicsTypeMap>
    {
        public planetSchematicsTypeMapMap()
        {
            // Primary Key
            this.HasKey(t => new { t.schematicID, t.typeID });

            // Properties
            this.Property(t => t.schematicID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("planetSchematicsTypeMap");
            this.Property(t => t.schematicID).HasColumnName("schematicID");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.isInput).HasColumnName("isInput");
        }
    }
}
