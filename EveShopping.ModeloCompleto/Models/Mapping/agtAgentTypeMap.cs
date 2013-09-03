using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class agtAgentTypeMap : EntityTypeConfiguration<agtAgentType>
    {
        public agtAgentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.agentTypeID);

            // Properties
            this.Property(t => t.agentTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.agentType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("agtAgentTypes");
            this.Property(t => t.agentTypeID).HasColumnName("agentTypeID");
            this.Property(t => t.agentType).HasColumnName("agentType");
        }
    }
}
