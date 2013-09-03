using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class ramAssemblyLineStationMap : EntityTypeConfiguration<ramAssemblyLineStation>
    {
        public ramAssemblyLineStationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.stationID, t.assemblyLineTypeID });

            // Properties
            this.Property(t => t.stationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ramAssemblyLineStations");
            this.Property(t => t.stationID).HasColumnName("stationID");
            this.Property(t => t.assemblyLineTypeID).HasColumnName("assemblyLineTypeID");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.stationTypeID).HasColumnName("stationTypeID");
            this.Property(t => t.ownerID).HasColumnName("ownerID");
            this.Property(t => t.solarSystemID).HasColumnName("solarSystemID");
            this.Property(t => t.regionID).HasColumnName("regionID");
        }
    }
}
