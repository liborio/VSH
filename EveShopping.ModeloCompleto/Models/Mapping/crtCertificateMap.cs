using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class crtCertificateMap : EntityTypeConfiguration<crtCertificate>
    {
        public crtCertificateMap()
        {
            // Primary Key
            this.HasKey(t => t.certificateID);

            // Properties
            this.Property(t => t.certificateID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("crtCertificates");
            this.Property(t => t.certificateID).HasColumnName("certificateID");
            this.Property(t => t.categoryID).HasColumnName("categoryID");
            this.Property(t => t.classID).HasColumnName("classID");
            this.Property(t => t.grade).HasColumnName("grade");
            this.Property(t => t.corpID).HasColumnName("corpID");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
