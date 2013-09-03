using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class crpNPCDivisionMap : EntityTypeConfiguration<crpNPCDivision>
    {
        public crpNPCDivisionMap()
        {
            // Primary Key
            this.HasKey(t => t.divisionID);

            // Properties
            this.Property(t => t.divisionName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            this.Property(t => t.leaderType)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("crpNPCDivisions");
            this.Property(t => t.divisionID).HasColumnName("divisionID");
            this.Property(t => t.divisionName).HasColumnName("divisionName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.leaderType).HasColumnName("leaderType");
        }
    }
}
