using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class invGroupMap : EntityTypeConfiguration<invGroup>
    {
        public invGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.groupID);

            // Properties
            this.Property(t => t.groupID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.groupName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(3000);

            // Table & Column Mappings
            this.ToTable("invGroups");
            this.Property(t => t.groupID).HasColumnName("groupID");
            this.Property(t => t.categoryID).HasColumnName("categoryID");
            this.Property(t => t.groupName).HasColumnName("groupName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.useBasePrice).HasColumnName("useBasePrice");
            this.Property(t => t.allowManufacture).HasColumnName("allowManufacture");
            this.Property(t => t.allowRecycler).HasColumnName("allowRecycler");
            this.Property(t => t.anchored).HasColumnName("anchored");
            this.Property(t => t.anchorable).HasColumnName("anchorable");
            this.Property(t => t.fittableNonSingleton).HasColumnName("fittableNonSingleton");
            this.Property(t => t.published).HasColumnName("published");
        }
    }
}
