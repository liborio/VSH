using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class invTypeMap : EntityTypeConfiguration<invType>
    {
        public invTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.typeID);

            // Properties
            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typeName)
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(3000);

            // Table & Column Mappings
            this.ToTable("invTypes");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.groupID).HasColumnName("groupID");
            this.Property(t => t.typeName).HasColumnName("typeName");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.mass).HasColumnName("mass");
            this.Property(t => t.volume).HasColumnName("volume");
            this.Property(t => t.capacity).HasColumnName("capacity");
            this.Property(t => t.portionSize).HasColumnName("portionSize");
            this.Property(t => t.raceID).HasColumnName("raceID");
            this.Property(t => t.basePrice).HasColumnName("basePrice");
            this.Property(t => t.published).HasColumnName("published");
            this.Property(t => t.marketGroupID).HasColumnName("marketGroupID");
            this.Property(t => t.chanceOfDuplicating).HasColumnName("chanceOfDuplicating");
        }
    }
}
