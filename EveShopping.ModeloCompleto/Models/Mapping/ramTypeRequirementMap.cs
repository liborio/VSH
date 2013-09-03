using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class ramTypeRequirementMap : EntityTypeConfiguration<ramTypeRequirement>
    {
        public ramTypeRequirementMap()
        {
            // Primary Key
            this.HasKey(t => new { t.typeID, t.activityID, t.requiredTypeID });

            // Properties
            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.requiredTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ramTypeRequirements");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.activityID).HasColumnName("activityID");
            this.Property(t => t.requiredTypeID).HasColumnName("requiredTypeID");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.damagePerJob).HasColumnName("damagePerJob");
            this.Property(t => t.recycle).HasColumnName("recycle");
        }
    }
}
