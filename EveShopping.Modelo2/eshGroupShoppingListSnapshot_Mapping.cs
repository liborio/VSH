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
    
    internal partial class eshGroupShoppingListSnapshot_Mapping : EntityTypeConfiguration<eshGroupShoppingListSnapshot>
    {
        public eshGroupShoppingListSnapshot_Mapping()
        {                        
              this.HasKey(t => new {t.groupShoppingListID, t.snapshotID});        
              this.ToTable("eshGroupShoppingListSnapshot");
              this.Property(t => t.groupShoppingListID).HasColumnName("groupShoppingListID").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
              this.Property(t => t.snapshotID).HasColumnName("snapshotID").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
              this.Property(t => t.nickName).HasColumnName("nickName").IsRequired().HasMaxLength(50);
              this.Property(t => t.creationDate).HasColumnName("creationDate");
              this.HasRequired(t => t.eshGroupShoppingList).WithMany(t => t.eshGroupShoppingListSnapshots).HasForeignKey(d => d.groupShoppingListID);
              this.HasRequired(t => t.eshSnapshot).WithMany(t => t.eshGroupShoppingListSnapshots).HasForeignKey(d => d.snapshotID);
         }
    }
}
