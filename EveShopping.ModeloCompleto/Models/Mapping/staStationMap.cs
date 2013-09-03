using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class staStationMap : EntityTypeConfiguration<staStation>
    {
        public staStationMap()
        {
            // Primary Key
            this.HasKey(t => t.stationID);

            // Properties
            this.Property(t => t.stationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.stationName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("staStations");
            this.Property(t => t.stationID).HasColumnName("stationID");
            this.Property(t => t.security).HasColumnName("security");
            this.Property(t => t.dockingCostPerVolume).HasColumnName("dockingCostPerVolume");
            this.Property(t => t.maxShipVolumeDockable).HasColumnName("maxShipVolumeDockable");
            this.Property(t => t.officeRentalCost).HasColumnName("officeRentalCost");
            this.Property(t => t.operationID).HasColumnName("operationID");
            this.Property(t => t.stationTypeID).HasColumnName("stationTypeID");
            this.Property(t => t.corporationID).HasColumnName("corporationID");
            this.Property(t => t.solarSystemID).HasColumnName("solarSystemID");
            this.Property(t => t.constellationID).HasColumnName("constellationID");
            this.Property(t => t.regionID).HasColumnName("regionID");
            this.Property(t => t.stationName).HasColumnName("stationName");
            this.Property(t => t.x).HasColumnName("x");
            this.Property(t => t.y).HasColumnName("y");
            this.Property(t => t.z).HasColumnName("z");
            this.Property(t => t.reprocessingEfficiency).HasColumnName("reprocessingEfficiency");
            this.Property(t => t.reprocessingStationsTake).HasColumnName("reprocessingStationsTake");
            this.Property(t => t.reprocessingHangarFlag).HasColumnName("reprocessingHangarFlag");
        }
    }
}
