using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class crpNPCCorporationResearchFieldMap : EntityTypeConfiguration<crpNPCCorporationResearchField>
    {
        public crpNPCCorporationResearchFieldMap()
        {
            // Primary Key
            this.HasKey(t => new { t.skillID, t.corporationID });

            // Properties
            this.Property(t => t.skillID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.corporationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("crpNPCCorporationResearchFields");
            this.Property(t => t.skillID).HasColumnName("skillID");
            this.Property(t => t.corporationID).HasColumnName("corporationID");
        }
    }
}
