using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class dgmAttributeCategoryMap : EntityTypeConfiguration<dgmAttributeCategory>
    {
        public dgmAttributeCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.categoryID);

            // Properties
            this.Property(t => t.categoryName)
                .HasMaxLength(50);

            this.Property(t => t.categoryDescription)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("dgmAttributeCategories");
            this.Property(t => t.categoryID).HasColumnName("categoryID");
            this.Property(t => t.categoryName).HasColumnName("categoryName");
            this.Property(t => t.categoryDescription).HasColumnName("categoryDescription");
        }
    }
}
