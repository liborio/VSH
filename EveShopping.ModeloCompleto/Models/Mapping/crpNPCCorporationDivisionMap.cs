using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class crpNPCCorporationDivisionMap : EntityTypeConfiguration<crpNPCCorporationDivision>
    {
        public crpNPCCorporationDivisionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.corporationID, t.divisionID });

            // Properties
            this.Property(t => t.corporationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("crpNPCCorporationDivisions");
            this.Property(t => t.corporationID).HasColumnName("corporationID");
            this.Property(t => t.divisionID).HasColumnName("divisionID");
            this.Property(t => t.size).HasColumnName("size");
        }
    }
}
