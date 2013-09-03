using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class planetSchematicMap : EntityTypeConfiguration<planetSchematic>
    {
        public planetSchematicMap()
        {
            // Primary Key
            this.HasKey(t => t.schematicID);

            // Properties
            this.Property(t => t.schematicID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.schematicName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("planetSchematics");
            this.Property(t => t.schematicID).HasColumnName("schematicID");
            this.Property(t => t.schematicName).HasColumnName("schematicName");
            this.Property(t => t.cycleTime).HasColumnName("cycleTime");
        }
    }
}
