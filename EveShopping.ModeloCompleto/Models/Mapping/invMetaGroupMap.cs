using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class invMetaGroupMap : EntityTypeConfiguration<invMetaGroup>
    {
        public invMetaGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.metaGroupID);

            // Properties
            this.Property(t => t.metaGroupID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.metaGroupName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("invMetaGroups");
            this.Property(t => t.metaGroupID).HasColumnName("metaGroupID");
            this.Property(t => t.metaGroupName).HasColumnName("metaGroupName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.iconID).HasColumnName("iconID");
        }
    }
}
