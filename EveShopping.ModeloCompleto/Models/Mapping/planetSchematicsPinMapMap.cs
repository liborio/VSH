using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class planetSchematicsPinMapMap : EntityTypeConfiguration<planetSchematicsPinMap>
    {
        public planetSchematicsPinMapMap()
        {
            // Primary Key
            this.HasKey(t => new { t.schematicID, t.pinTypeID });

            // Properties
            this.Property(t => t.schematicID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pinTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("planetSchematicsPinMap");
            this.Property(t => t.schematicID).HasColumnName("schematicID");
            this.Property(t => t.pinTypeID).HasColumnName("pinTypeID");
        }
    }
}
