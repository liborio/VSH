using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshTinyUrlMap : EntityTypeConfiguration<eshTinyUrlMapping>
    {
        public eshTinyUrlMap()
        {
            // Primary Key
            this.HasKey(t => t.urlId);

            // Properties
            
            this.Property(t => t.tinyUrl)
                .HasMaxLength(50);

            this.Property(t => t.finalUrl)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("eshTinyUrlMapping");
            this.Property(t => t.urlId).HasColumnName("urlId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);;
            this.Property(t => t.tinyUrl).HasColumnName("tinyUrl");
            this.Property(t => t.finalUrl).HasColumnName("finalUrl");

        }
    }
}
