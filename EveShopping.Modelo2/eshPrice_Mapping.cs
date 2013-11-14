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
    
    internal partial class eshPrice_Mapping : EntityTypeConfiguration<eshPrice>
    {
        public eshPrice_Mapping()
        {                        
              this.HasKey(t => new {t.typeID, t.solarSystemID});        
              this.ToTable("eshPrices");
              this.Property(t => t.typeID).HasColumnName("typeID").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
              this.Property(t => t.solarSystemID).HasColumnName("solarSystemID").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
              this.Property(t => t.avg).HasColumnName("avg");
              this.Property(t => t.updateTime).HasColumnName("updateTime");
              this.HasRequired(t => t.invType).WithMany(t => t.eshPrices).HasForeignKey(d => d.typeID);
              this.HasRequired(t => t.mapSolarSystem).WithMany(t => t.eshPrices).HasForeignKey(d => d.solarSystemID);
         }
    }
}
