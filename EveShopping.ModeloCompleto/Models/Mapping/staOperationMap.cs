using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class staOperationMap : EntityTypeConfiguration<staOperation>
    {
        public staOperationMap()
        {
            // Primary Key
            this.HasKey(t => t.operationID);

            // Properties
            this.Property(t => t.operationName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("staOperations");
            this.Property(t => t.activityID).HasColumnName("activityID");
            this.Property(t => t.operationID).HasColumnName("operationID");
            this.Property(t => t.operationName).HasColumnName("operationName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.fringe).HasColumnName("fringe");
            this.Property(t => t.corridor).HasColumnName("corridor");
            this.Property(t => t.hub).HasColumnName("hub");
            this.Property(t => t.border).HasColumnName("border");
            this.Property(t => t.ratio).HasColumnName("ratio");
            this.Property(t => t.caldariStationTypeID).HasColumnName("caldariStationTypeID");
            this.Property(t => t.minmatarStationTypeID).HasColumnName("minmatarStationTypeID");
            this.Property(t => t.amarrStationTypeID).HasColumnName("amarrStationTypeID");
            this.Property(t => t.gallenteStationTypeID).HasColumnName("gallenteStationTypeID");
            this.Property(t => t.joveStationTypeID).HasColumnName("joveStationTypeID");
        }
    }
}
