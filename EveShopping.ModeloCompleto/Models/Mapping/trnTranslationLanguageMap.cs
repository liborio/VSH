using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class trnTranslationLanguageMap : EntityTypeConfiguration<trnTranslationLanguage>
    {
        public trnTranslationLanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.numericLanguageID);

            // Properties
            this.Property(t => t.numericLanguageID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.languageID)
                .HasMaxLength(50);

            this.Property(t => t.languageName)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("trnTranslationLanguages");
            this.Property(t => t.numericLanguageID).HasColumnName("numericLanguageID");
            this.Property(t => t.languageID).HasColumnName("languageID");
            this.Property(t => t.languageName).HasColumnName("languageName");
        }
    }
}
