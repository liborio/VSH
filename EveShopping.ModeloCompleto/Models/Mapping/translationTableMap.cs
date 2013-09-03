using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class translationTableMap : EntityTypeConfiguration<translationTable>
    {
        public translationTableMap()
        {
            // Primary Key
            this.HasKey(t => new { t.sourceTable, t.translatedKey });

            // Properties
            this.Property(t => t.sourceTable)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.destinationTable)
                .HasMaxLength(200);

            this.Property(t => t.translatedKey)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("translationTables");
            this.Property(t => t.sourceTable).HasColumnName("sourceTable");
            this.Property(t => t.destinationTable).HasColumnName("destinationTable");
            this.Property(t => t.translatedKey).HasColumnName("translatedKey");
            this.Property(t => t.tcGroupID).HasColumnName("tcGroupID");
            this.Property(t => t.tcID).HasColumnName("tcID");
        }
    }
}
