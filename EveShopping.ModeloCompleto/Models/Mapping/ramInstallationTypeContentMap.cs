using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class ramInstallationTypeContentMap : EntityTypeConfiguration<ramInstallationTypeContent>
    {
        public ramInstallationTypeContentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.installationTypeID, t.assemblyLineTypeID });

            // Properties
            this.Property(t => t.installationTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ramInstallationTypeContents");
            this.Property(t => t.installationTypeID).HasColumnName("installationTypeID");
            this.Property(t => t.assemblyLineTypeID).HasColumnName("assemblyLineTypeID");
            this.Property(t => t.quantity).HasColumnName("quantity");
        }
    }
}
