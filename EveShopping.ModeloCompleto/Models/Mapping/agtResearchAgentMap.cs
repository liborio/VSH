using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class agtResearchAgentMap : EntityTypeConfiguration<agtResearchAgent>
    {
        public agtResearchAgentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.agentID, t.typeID });

            // Properties
            this.Property(t => t.agentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("agtResearchAgents");
            this.Property(t => t.agentID).HasColumnName("agentID");
            this.Property(t => t.typeID).HasColumnName("typeID");
        }
    }
}
