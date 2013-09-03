using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class mapLocationSceneMap : EntityTypeConfiguration<mapLocationScene>
    {
        public mapLocationSceneMap()
        {
            // Primary Key
            this.HasKey(t => t.locationID);

            // Properties
            this.Property(t => t.locationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("mapLocationScenes");
            this.Property(t => t.locationID).HasColumnName("locationID");
            this.Property(t => t.graphicID).HasColumnName("graphicID");
        }
    }
}
