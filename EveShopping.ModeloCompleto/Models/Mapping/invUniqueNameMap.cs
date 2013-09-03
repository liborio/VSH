using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class invUniqueNameMap : EntityTypeConfiguration<invUniqueName>
    {
        public invUniqueNameMap()
        {
            // Primary Key
            this.HasKey(t => t.itemID);

            // Properties
            this.Property(t => t.itemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.itemName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("invUniqueNames");
            this.Property(t => t.itemID).HasColumnName("itemID");
            this.Property(t => t.itemName).HasColumnName("itemName");
            this.Property(t => t.groupID).HasColumnName("groupID");
        }
    }
}
