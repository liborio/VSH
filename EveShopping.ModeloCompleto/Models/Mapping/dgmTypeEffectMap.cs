using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class dgmTypeEffectMap : EntityTypeConfiguration<dgmTypeEffect>
    {
        public dgmTypeEffectMap()
        {
            // Primary Key
            this.HasKey(t => new { t.typeID, t.effectID });

            // Properties
            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.effectID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("dgmTypeEffects");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.effectID).HasColumnName("effectID");
            this.Property(t => t.isDefault).HasColumnName("isDefault");
        }
    }
}
