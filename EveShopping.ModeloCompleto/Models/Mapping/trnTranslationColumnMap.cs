using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class trnTranslationColumnMap : EntityTypeConfiguration<trnTranslationColumn>
    {
        public trnTranslationColumnMap()
        {
            // Primary Key
            this.HasKey(t => t.tcID);

            // Properties
            this.Property(t => t.tcID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.tableName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.columnName)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.masterID)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("trnTranslationColumns");
            this.Property(t => t.tcGroupID).HasColumnName("tcGroupID");
            this.Property(t => t.tcID).HasColumnName("tcID");
            this.Property(t => t.tableName).HasColumnName("tableName");
            this.Property(t => t.columnName).HasColumnName("columnName");
            this.Property(t => t.masterID).HasColumnName("masterID");
        }
    }
}
