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
    
    internal partial class eshTinyUrlMapping_Mapping : EntityTypeConfiguration<eshTinyUrlMapping>
    {
        public eshTinyUrlMapping_Mapping()
        {                        
              this.HasKey(t => t.urlId);        
              this.ToTable("eshTinyUrlMapping");
              this.Property(t => t.urlId).HasColumnName("urlId").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
              this.Property(t => t.tinyUrl).HasColumnName("tinyUrl").HasMaxLength(50);
              this.Property(t => t.finalUrl).HasColumnName("finalUrl").HasMaxLength(250);
              this.Property(t => t.isPermanent).HasColumnName("isPermanent");
              this.Property(t => t.lastGivenTime).HasColumnName("lastGivenTime");
         }
    }
}
