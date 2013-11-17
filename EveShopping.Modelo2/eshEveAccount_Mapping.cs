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
    
    internal partial class eshEveAccount_Mapping : EntityTypeConfiguration<eshEveAccount>
    {
        public eshEveAccount_Mapping()
        {                        
              this.HasKey(t => t.accountID);        
              this.ToTable("eshEveAccount");
              this.Property(t => t.accountID).HasColumnName("accountID");
              this.Property(t => t.userID).HasColumnName("userID");
              this.Property(t => t.keyID).HasColumnName("keyID");
              this.Property(t => t.verficationCode).HasColumnName("verficationCode").IsRequired().HasMaxLength(200);
              this.Property(t => t.isActive).HasColumnName("isActive");
              this.Property(t => t.dateCreation).HasColumnName("dateCreation");
              this.Property(t => t.dateUpdate).HasColumnName("dateUpdate");
              this.HasRequired(t => t.UserProfile).WithMany(t => t.eshEveAccounts).HasForeignKey(d => d.userID);
         }
    }
}