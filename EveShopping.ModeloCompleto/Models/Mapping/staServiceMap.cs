using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class staServiceMap : EntityTypeConfiguration<staService>
    {
        public staServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.serviceID);

            // Properties
            this.Property(t => t.serviceID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.serviceName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("staServices");
            this.Property(t => t.serviceID).HasColumnName("serviceID");
            this.Property(t => t.serviceName).HasColumnName("serviceName");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
