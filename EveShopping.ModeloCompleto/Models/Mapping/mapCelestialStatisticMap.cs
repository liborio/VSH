using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class mapCelestialStatisticMap : EntityTypeConfiguration<mapCelestialStatistic>
    {
        public mapCelestialStatisticMap()
        {
            // Primary Key
            this.HasKey(t => t.celestialID);

            // Properties
            this.Property(t => t.celestialID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.spectralClass)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("mapCelestialStatistics");
            this.Property(t => t.celestialID).HasColumnName("celestialID");
            this.Property(t => t.temperature).HasColumnName("temperature");
            this.Property(t => t.spectralClass).HasColumnName("spectralClass");
            this.Property(t => t.luminosity).HasColumnName("luminosity");
            this.Property(t => t.age).HasColumnName("age");
            this.Property(t => t.life).HasColumnName("life");
            this.Property(t => t.orbitRadius).HasColumnName("orbitRadius");
            this.Property(t => t.eccentricity).HasColumnName("eccentricity");
            this.Property(t => t.massDust).HasColumnName("massDust");
            this.Property(t => t.massGas).HasColumnName("massGas");
            this.Property(t => t.fragmented).HasColumnName("fragmented");
            this.Property(t => t.density).HasColumnName("density");
            this.Property(t => t.surfaceGravity).HasColumnName("surfaceGravity");
            this.Property(t => t.escapeVelocity).HasColumnName("escapeVelocity");
            this.Property(t => t.orbitPeriod).HasColumnName("orbitPeriod");
            this.Property(t => t.rotationRate).HasColumnName("rotationRate");
            this.Property(t => t.locked).HasColumnName("locked");
            this.Property(t => t.pressure).HasColumnName("pressure");
            this.Property(t => t.radius).HasColumnName("radius");
            this.Property(t => t.mass).HasColumnName("mass");
        }
    }
}
