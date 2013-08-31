using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class dgmEffectMap : EntityTypeConfiguration<dgmEffect>
    {
        public dgmEffectMap()
        {
            // Primary Key
            this.HasKey(t => t.effectID);

            // Properties
            this.Property(t => t.effectID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.effectName)
                .HasMaxLength(400);

            this.Property(t => t.description)
                .HasMaxLength(1000);

            this.Property(t => t.guid)
                .HasMaxLength(60);

            this.Property(t => t.displayName)
                .HasMaxLength(100);

            this.Property(t => t.sfxName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("dgmEffects");
            this.Property(t => t.effectID).HasColumnName("effectID");
            this.Property(t => t.effectName).HasColumnName("effectName");
            this.Property(t => t.effectCategory).HasColumnName("effectCategory");
            this.Property(t => t.preExpression).HasColumnName("preExpression");
            this.Property(t => t.postExpression).HasColumnName("postExpression");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.guid).HasColumnName("guid");
            this.Property(t => t.iconID).HasColumnName("iconID");
            this.Property(t => t.isOffensive).HasColumnName("isOffensive");
            this.Property(t => t.isAssistance).HasColumnName("isAssistance");
            this.Property(t => t.durationAttributeID).HasColumnName("durationAttributeID");
            this.Property(t => t.trackingSpeedAttributeID).HasColumnName("trackingSpeedAttributeID");
            this.Property(t => t.dischargeAttributeID).HasColumnName("dischargeAttributeID");
            this.Property(t => t.rangeAttributeID).HasColumnName("rangeAttributeID");
            this.Property(t => t.falloffAttributeID).HasColumnName("falloffAttributeID");
            this.Property(t => t.disallowAutoRepeat).HasColumnName("disallowAutoRepeat");
            this.Property(t => t.published).HasColumnName("published");
            this.Property(t => t.displayName).HasColumnName("displayName");
            this.Property(t => t.isWarpSafe).HasColumnName("isWarpSafe");
            this.Property(t => t.rangeChance).HasColumnName("rangeChance");
            this.Property(t => t.electronicChance).HasColumnName("electronicChance");
            this.Property(t => t.propulsionChance).HasColumnName("propulsionChance");
            this.Property(t => t.distribution).HasColumnName("distribution");
            this.Property(t => t.sfxName).HasColumnName("sfxName");
            this.Property(t => t.npcUsageChanceAttributeID).HasColumnName("npcUsageChanceAttributeID");
            this.Property(t => t.npcActivationChanceAttributeID).HasColumnName("npcActivationChanceAttributeID");
            this.Property(t => t.fittingUsageChanceAttributeID).HasColumnName("fittingUsageChanceAttributeID");
        }
    }
}
