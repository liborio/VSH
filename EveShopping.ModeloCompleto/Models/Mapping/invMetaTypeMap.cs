using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class invMetaTypeMap : EntityTypeConfiguration<invMetaType>
    {
        public invMetaTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.typeID);

            // Properties
            this.Property(t => t.typeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("invMetaTypes");
            this.Property(t => t.typeID).HasColumnName("typeID");
            this.Property(t => t.parentTypeID).HasColumnName("parentTypeID");
            this.Property(t => t.metaGroupID).HasColumnName("metaGroupID");
        }
    }
}
