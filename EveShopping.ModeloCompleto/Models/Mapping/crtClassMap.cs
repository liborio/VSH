using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class crtClassMap : EntityTypeConfiguration<crtClass>
    {
        public crtClassMap()
        {
            // Primary Key
            this.HasKey(t => t.classID);

            // Properties
            this.Property(t => t.classID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(500);

            this.Property(t => t.className)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("crtClasses");
            this.Property(t => t.classID).HasColumnName("classID");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.className).HasColumnName("className");
        }
    }
}
