using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class ramAssemblyLineMap : EntityTypeConfiguration<ramAssemblyLine>
    {
        public ramAssemblyLineMap()
        {
            // Primary Key
            this.HasKey(t => t.assemblyLineID);

            // Properties
            this.Property(t => t.assemblyLineID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ramAssemblyLines");
            this.Property(t => t.assemblyLineID).HasColumnName("assemblyLineID");
            this.Property(t => t.assemblyLineTypeID).HasColumnName("assemblyLineTypeID");
            this.Property(t => t.containerID).HasColumnName("containerID");
            this.Property(t => t.nextFreeTime).HasColumnName("nextFreeTime");
            this.Property(t => t.UIGroupingID).HasColumnName("UIGroupingID");
            this.Property(t => t.costInstall).HasColumnName("costInstall");
            this.Property(t => t.costPerHour).HasColumnName("costPerHour");
            this.Property(t => t.restrictionMask).HasColumnName("restrictionMask");
            this.Property(t => t.discountPerGoodStandingPoint).HasColumnName("discountPerGoodStandingPoint");
            this.Property(t => t.surchargePerBadStandingPoint).HasColumnName("surchargePerBadStandingPoint");
            this.Property(t => t.minimumStanding).HasColumnName("minimumStanding");
            this.Property(t => t.minimumCharSecurity).HasColumnName("minimumCharSecurity");
            this.Property(t => t.minimumCorpSecurity).HasColumnName("minimumCorpSecurity");
            this.Property(t => t.maximumCharSecurity).HasColumnName("maximumCharSecurity");
            this.Property(t => t.maximumCorpSecurity).HasColumnName("maximumCorpSecurity");
            this.Property(t => t.ownerID).HasColumnName("ownerID");
            this.Property(t => t.activityID).HasColumnName("activityID");
        }
    }
}
