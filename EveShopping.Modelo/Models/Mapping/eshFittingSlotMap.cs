using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshFittingSlotMap : EntityTypeConfiguration<eshFittingSlot>
    {
        public eshFittingSlotMap()
        {
            // Primary Key
            this.HasKey(t => t.slotID);

            // Properties
            this.Property(t => t.slotID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("eshFittingSlots");
            this.Property(t => t.slotID).HasColumnName("slotID");
            this.Property(t => t.name).HasColumnName("name");
        }
    }
}
