using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class crpActivityMap : EntityTypeConfiguration<crpActivity>
    {
        public crpActivityMap()
        {
            // Primary Key
            this.HasKey(t => t.activityID);

            // Properties
            this.Property(t => t.activityName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("crpActivities");
            this.Property(t => t.activityID).HasColumnName("activityID");
            this.Property(t => t.activityName).HasColumnName("activityName");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
