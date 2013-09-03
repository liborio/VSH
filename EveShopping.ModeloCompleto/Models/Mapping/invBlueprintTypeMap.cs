using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class invBlueprintTypeMap : EntityTypeConfiguration<invBlueprintType>
    {
        public invBlueprintTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.blueprintTypeID);

            // Properties
            this.Property(t => t.blueprintTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("invBlueprintTypes");
            this.Property(t => t.blueprintTypeID).HasColumnName("blueprintTypeID");
            this.Property(t => t.parentBlueprintTypeID).HasColumnName("parentBlueprintTypeID");
            this.Property(t => t.productTypeID).HasColumnName("productTypeID");
            this.Property(t => t.productionTime).HasColumnName("productionTime");
            this.Property(t => t.techLevel).HasColumnName("techLevel");
            this.Property(t => t.researchProductivityTime).HasColumnName("researchProductivityTime");
            this.Property(t => t.researchMaterialTime).HasColumnName("researchMaterialTime");
            this.Property(t => t.researchCopyTime).HasColumnName("researchCopyTime");
            this.Property(t => t.researchTechTime).HasColumnName("researchTechTime");
            this.Property(t => t.productivityModifier).HasColumnName("productivityModifier");
            this.Property(t => t.materialModifier).HasColumnName("materialModifier");
            this.Property(t => t.wasteFactor).HasColumnName("wasteFactor");
            this.Property(t => t.maxProductionLimit).HasColumnName("maxProductionLimit");
        }
    }
}
