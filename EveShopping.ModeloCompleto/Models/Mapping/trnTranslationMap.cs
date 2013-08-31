using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class trnTranslationMap : EntityTypeConfiguration<trnTranslation>
    {
        public trnTranslationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.tcID, t.keyID, t.languageID });

            // Properties
            this.Property(t => t.tcID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.keyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.languageID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.text)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("trnTranslations");
            this.Property(t => t.tcID).HasColumnName("tcID");
            this.Property(t => t.keyID).HasColumnName("keyID");
            this.Property(t => t.languageID).HasColumnName("languageID");
            this.Property(t => t.text).HasColumnName("text");
        }
    }
}
