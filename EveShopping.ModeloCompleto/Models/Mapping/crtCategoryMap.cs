using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class crtCategoryMap : EntityTypeConfiguration<crtCategory>
    {
        public crtCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.categoryID);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(500);

            this.Property(t => t.categoryName)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("crtCategories");
            this.Property(t => t.categoryID).HasColumnName("categoryID");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.categoryName).HasColumnName("categoryName");
        }
    }
}
