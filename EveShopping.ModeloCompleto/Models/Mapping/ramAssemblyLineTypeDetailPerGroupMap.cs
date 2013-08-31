using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class ramAssemblyLineTypeDetailPerGroupMap : EntityTypeConfiguration<ramAssemblyLineTypeDetailPerGroup>
    {
        public ramAssemblyLineTypeDetailPerGroupMap()
        {
            // Primary Key
            this.HasKey(t => new { t.assemblyLineTypeID, t.groupID });

            // Properties
            this.Property(t => t.groupID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ramAssemblyLineTypeDetailPerGroup");
            this.Property(t => t.assemblyLineTypeID).HasColumnName("assemblyLineTypeID");
            this.Property(t => t.groupID).HasColumnName("groupID");
            this.Property(t => t.timeMultiplier).HasColumnName("timeMultiplier");
            this.Property(t => t.materialMultiplier).HasColumnName("materialMultiplier");
        }
    }
}
