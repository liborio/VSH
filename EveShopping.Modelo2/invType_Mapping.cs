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
    
    internal partial class invType_Mapping : EntityTypeConfiguration<invType>
    {
        public invType_Mapping()
        {                        
              this.HasKey(t => t.typeID);        
              this.ToTable("invTypes");
              this.Property(t => t.typeID).HasColumnName("typeID").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
              this.Property(t => t.groupID).HasColumnName("groupID");
              this.Property(t => t.typeName).HasColumnName("typeName").HasMaxLength(100);
              this.Property(t => t.description).HasColumnName("description").HasMaxLength(3000);
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