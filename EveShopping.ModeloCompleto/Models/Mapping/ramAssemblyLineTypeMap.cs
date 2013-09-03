using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class ramAssemblyLineTypeMap : EntityTypeConfiguration<ramAssemblyLineType>
    {
        public ramAssemblyLineTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.assemblyLineTypeID);

            // Properties
            this.Property(t => t.assemblyLineTypeName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("ramAssemblyLineTypes");
            this.Property(t => t.assemblyLineTypeID).HasColumnName("assemblyLineTypeID");
            this.Property(t => t.assemblyLineTypeName).HasColumnName("assemblyLineTypeName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.baseTimeMultiplier).HasColumnName("baseTimeMultiplier");
            this.Property(t => t.baseMaterialMultiplier).HasColumnName("baseMaterialMultiplier");
            this.Property(t => t.volume).HasColumnName("volume");
            this.Property(t => t.activityID).HasColumnName("activityID");
            this.Property(t => t.minCostPerHour).HasColumnName("minCostPerHour");
        }
    }
}
