using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class invTypeReactionMap : EntityTypeConfiguration<invTypeReaction>
    {
        public invTypeReactionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.reactionTypeID, t.input, t.typeID });

            // Properties
            this.Property(t => t.reactionTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("invTypeReactions");
            this.Property(t => t.reactionTypeID).HasColumnName("reactionTypeID");
            this.Property(t => t.input).HasColumnName("input");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.quantity).HasColumnName("quantity");
        }
    }
}
