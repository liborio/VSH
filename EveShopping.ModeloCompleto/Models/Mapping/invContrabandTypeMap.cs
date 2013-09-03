using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class invContrabandTypeMap : EntityTypeConfiguration<invContrabandType>
    {
        public invContrabandTypeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.factionID, t.typeID });

            // Properties
            this.Property(t => t.factionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("invContrabandTypes");
            this.Property(t => t.factionID).HasColumnName("factionID");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.standingLoss).HasColumnName("standingLoss");
            this.Property(t => t.confiscateMinSec).HasColumnName("confiscateMinSec");
            this.Property(t => t.fineByValue).HasColumnName("fineByValue");
            this.Property(t => t.attackMinSec).HasColumnName("attackMinSec");
        }
    }
}
