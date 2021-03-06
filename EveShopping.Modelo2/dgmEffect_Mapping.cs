//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EveShopping.Modelo
{
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.Infrastructure;
    
    internal partial class dgmEffect_Mapping : EntityTypeConfiguration<dgmEffect>
    {
        public dgmEffect_Mapping()
        {                        
              this.HasKey(t => t.effectID);        
              this.ToTable("dgmEffects");
              this.Property(t => t.effectID).HasColumnName("effectID").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
              this.Property(t => t.effectName).HasColumnName("effectName").IsUnicode(false).HasMaxLength(400);
              this.Property(t => t.effectCategory).HasColumnName("effectCategory");
              this.Property(t => t.preExpression).HasColumnName("preExpression");
              this.Property(t => t.postExpression).HasColumnName("postExpression");
              this.Property(t => t.description).HasColumnName("description").IsUnicode(false).HasMaxLength(1000);
              this.Property(t => t.guid).HasColumnName("guid").IsUnicode(false).HasMaxLength(60);
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
              this.Property(t => t.displayName).HasColumnName("displayName").IsUnicode(false).HasMaxLength(100);
              this.Property(t => t.isWarpSafe).HasColumnName("isWarpSafe");
              this.Property(t => t.rangeChance).HasColumnName("rangeChance");
              this.Property(t => t.electronicChance).HasColumnName("electronicChance");
              this.Property(t => t.propulsionChance).HasColumnName("propulsionChance");
              this.Property(t => t.distribution).HasColumnName("distribution");
              this.Property(t => t.sfxName).HasColumnName("sfxName").IsUnicode(false).HasMaxLength(20);
              this.Property(t => t.npcUsageChanceAttributeID).HasColumnName("npcUsageChanceAttributeID");
              this.Property(t => t.npcActivationChanceAttributeID).HasColumnName("npcActivationChanceAttributeID");
              this.Property(t => t.fittingUsageChanceAttributeID).HasColumnName("fittingUsageChanceAttributeID");
         }
    }
}
