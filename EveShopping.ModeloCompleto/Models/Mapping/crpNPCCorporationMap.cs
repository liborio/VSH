using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class crpNPCCorporationMap : EntityTypeConfiguration<crpNPCCorporation>
    {
        public crpNPCCorporationMap()
        {
            // Primary Key
            this.HasKey(t => t.corporationID);

            // Properties
            this.Property(t => t.corporationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.size)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.extent)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.description)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("crpNPCCorporations");
            this.Property(t => t.corporationID).HasColumnName("corporationID");
            this.Property(t => t.size).HasColumnName("size");
            this.Property(t => t.extent).HasColumnName("extent");
            this.Property(t => t.solarSystemID).HasColumnName("solarSystemID");
            this.Property(t => t.investorID1).HasColumnName("investorID1");
            this.Property(t => t.investorShares1).HasColumnName("investorShares1");
            this.Property(t => t.investorID2).HasColumnName("investorID2");
            this.Property(t => t.investorShares2).HasColumnName("investorShares2");
            this.Property(t => t.investorID3).HasColumnName("investorID3");
            this.Property(t => t.investorShares3).HasColumnName("investorShares3");
            this.Property(t => t.investorID4).HasColumnName("investorID4");
            this.Property(t => t.investorShares4).HasColumnName("investorShares4");
            this.Property(t => t.friendID).HasColumnName("friendID");
            this.Property(t => t.enemyID).HasColumnName("enemyID");
            this.Property(t => t.publicShares).HasColumnName("publicShares");
            this.Property(t => t.initialPrice).HasColumnName("initialPrice");
            this.Property(t => t.minSecurity).HasColumnName("minSecurity");
            this.Property(t => t.scattered).HasColumnName("scattered");
            this.Property(t => t.fringe).HasColumnName("fringe");
            this.Property(t => t.corridor).HasColumnName("corridor");
            this.Property(t => t.hub).HasColumnName("hub");
            this.Property(t => t.border).HasColumnName("border");
            this.Property(t => t.factionID).HasColumnName("factionID");
            this.Property(t => t.sizeFactor).HasColumnName("sizeFactor");
            this.Property(t => t.stationCount).HasColumnName("stationCount");
            this.Property(t => t.stationSystemCount).HasColumnName("stationSystemCount");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.iconID).HasColumnName("iconID");
        }
    }
}
