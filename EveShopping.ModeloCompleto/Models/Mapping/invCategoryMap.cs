using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class invCategoryMap : EntityTypeConfiguration<invCategory>
    {
        public invCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.categoryID);

            // Properties
            this.Property(t => t.categoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.categoryName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(3000);

            // Table & Column Mappings
            this.ToTable("invCategories");
            this.Property(t => t.categoryID).HasColumnName("categoryID");
            this.Property(t => t.categoryName).HasColumnName("categoryName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.published).HasColumnName("published");
        }
    }
}
