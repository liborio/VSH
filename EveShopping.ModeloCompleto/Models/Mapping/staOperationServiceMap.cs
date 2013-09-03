using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class staOperationServiceMap : EntityTypeConfiguration<staOperationService>
    {
        public staOperationServiceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.operationID, t.serviceID });

            // Properties
            this.Property(t => t.serviceID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("staOperationServices");
            this.Property(t => t.operationID).HasColumnName("operationID");
            this.Property(t => t.serviceID).HasColumnName("serviceID");
        }
    }
}
