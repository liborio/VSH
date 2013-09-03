using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class staStationTypeMap : EntityTypeConfiguration<staStationType>
    {
        public staStationTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.stationTypeID);

            // Properties
            this.Property(t => t.stationTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("staStationTypes");
            this.Property(t => t.stationTypeID).HasColumnName("stationTypeID");
            this.Property(t => t.dockEntryX).HasColumnName("dockEntryX");
            this.Property(t => t.dockEntryY).HasColumnName("dockEntryY");
            this.Property(t => t.dockEntryZ).HasColumnName("dockEntryZ");
            this.Property(t => t.dockOrientationX).HasColumnName("dockOrientationX");
            this.Property(t => t.dockOrientationY).HasColumnName("dockOrientationY");
            this.Property(t => t.dockOrientationZ).HasColumnName("dockOrientationZ");
            this.Property(t => t.operationID).HasColumnName("operationID");
            this.Property(t => t.officeSlots).HasColumnName("officeSlots");
            this.Property(t => t.reprocessingEfficiency).HasColumnName("reprocessingEfficiency");
            this.Property(t => t.conquerable).HasColumnName("conquerable");
        }
    }
}
