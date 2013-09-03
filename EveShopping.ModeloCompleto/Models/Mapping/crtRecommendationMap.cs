using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class crtRecommendationMap : EntityTypeConfiguration<crtRecommendation>
    {
        public crtRecommendationMap()
        {
            // Primary Key
            this.HasKey(t => t.recommendationID);

            // Properties
            this.Property(t => t.recommendationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("crtRecommendations");
            this.Property(t => t.recommendationID).HasColumnName("recommendationID");
            this.Property(t => t.shipTypeID).HasColumnName("shipTypeID");
            this.Property(t => t.certificateID).HasColumnName("certificateID");
            this.Property(t => t.recommendationLevel).HasColumnName("recommendationLevel");
        }
    }
}
