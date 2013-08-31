using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class ramActivityMap : EntityTypeConfiguration<ramActivity>
    {
        public ramActivityMap()
        {
            // Primary Key
            this.HasKey(t => t.activityID);

            // Properties
            this.Property(t => t.activityName)
                .HasMaxLength(100);

            this.Property(t => t.iconNo)
                .HasMaxLength(5);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("ramActivities");
            this.Property(t => t.activityID).HasColumnName("activityID");
            this.Property(t => t.activityName).HasColumnName("activityName");
            this.Property(t => t.iconNo).HasColumnName("iconNo");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.published).HasColumnName("published");
        }
    }
}
