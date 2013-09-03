using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class agtAgentMap : EntityTypeConfiguration<agtAgent>
    {
        public agtAgentMap()
        {
            // Primary Key
            this.HasKey(t => t.agentID);

            // Properties
            this.Property(t => t.agentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("agtAgents");
            this.Property(t => t.agentID).HasColumnName("agentID");
            this.Property(t => t.divisionID).HasColumnName("divisionID");
            this.Property(t => t.corporationID).HasColumnName("corporationID");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.level).HasColumnName("level");
            this.Property(t => t.quality).HasColumnName("quality");
            this.Property(t => t.agentTypeID).HasColumnName("agentTypeID");
            this.Property(t => t.isLocator).HasColumnName("isLocator");
        }
    }
}
