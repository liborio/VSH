using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class invMarketGroupMap : EntityTypeConfiguration<invMarketGroup>
    {
        public invMarketGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.marketGroupID);

            // Properties
            this.Property(t => t.marketGroupID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.marketGroupName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(3000);

            // Table & Column Mappings
            this.ToTable("invMarketGroups");
            this.Property(t => t.marketGroupID).HasColumnName("marketGroupID");
            this.Property(t => t.parentGroupID).HasColumnName("parentGroupID");
            this.Property(t => t.marketGroupName).HasColumnName("marketGroupName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.hasTypes).HasColumnName("hasTypes");
        }
    }
}
