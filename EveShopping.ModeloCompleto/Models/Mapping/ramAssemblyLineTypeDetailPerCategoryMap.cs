using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class ramAssemblyLineTypeDetailPerCategoryMap : EntityTypeConfiguration<ramAssemblyLineTypeDetailPerCategory>
    {
        public ramAssemblyLineTypeDetailPerCategoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.assemblyLineTypeID, t.categoryID });

            // Properties
            this.Property(t => t.categoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ramAssemblyLineTypeDetailPerCategory");
            this.Property(t => t.assemblyLineTypeID).HasColumnName("assemblyLineTypeID");
            this.Property(t => t.categoryID).HasColumnName("categoryID");
            this.Property(t => t.timeMultiplier).HasColumnName("timeMultiplier");
            this.Property(t => t.materialMultiplier).HasColumnName("materialMultiplier");
        }
    }
}
