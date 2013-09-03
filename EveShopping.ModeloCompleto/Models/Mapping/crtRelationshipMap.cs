using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Mapping
{
    public class crtRelationshipMap : EntityTypeConfiguration<crtRelationship>
    {
        public crtRelationshipMap()
        {
            // Primary Key
            this.HasKey(t => t.relationshipID);

            // Properties
            this.Property(t => t.relationshipID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("crtRelationships");
            this.Property(t => t.relationshipID).HasColumnName("relationshipID");
            this.Property(t => t.parentID).HasColumnName("parentID");
            this.Property(t => t.parentTypeID).HasColumnName("parentTypeID");
            this.Property(t => t.parentLevel).HasColumnName("parentLevel");
            this.Property(t => t.childID).HasColumnName("childID");
        }
    }
}
