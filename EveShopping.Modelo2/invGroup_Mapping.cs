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
    
    internal partial class invGroup_Mapping : EntityTypeConfiguration<invGroup>
    {
        public invGroup_Mapping()
        {                        
              this.HasKey(t => t.groupID);        
              this.ToTable("invGroups");
              this.Property(t => t.groupID).HasColumnName("groupID").HasDatabaseGeneratedOption(new Nullable<DatabaseGeneratedOption>(DatabaseGeneratedOption.None));
              this.Property(t => t.categoryID).HasColumnName("categoryID");
              this.Property(t => t.groupName).HasColumnName("groupName").HasMaxLength(100);
              this.Property(t => t.description).HasColumnName("description").HasMaxLength(3000);
              this.Property(t => t.iconID).HasColumnName("iconID");
              this.Property(t => t.useBasePrice).HasColumnName("useBasePrice");
              this.Property(t => t.allowManufacture).HasColumnName("allowManufacture");
              this.Property(t => t.allowRecycler).HasColumnName("allowRecycler");
              this.Property(t => t.anchored).HasColumnName("anchored");
              this.Property(t => t.anchorable).HasColumnName("anchorable");
              this.Property(t => t.fittableNonSingleton).HasColumnName("fittableNonSingleton");
              this.Property(t => t.published).HasColumnName("published");
         }
    }
}