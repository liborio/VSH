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
    
    internal partial class eshLog_Mapping : EntityTypeConfiguration<eshLog>
    {
        public eshLog_Mapping()
        {                        
              this.HasKey(t => t.LogID);        
              this.ToTable("eshLogs");
              this.Property(t => t.LogID).HasColumnName("LogID");
              this.Property(t => t.Code).HasColumnName("Code");
              this.Property(t => t.Severity).HasColumnName("Severity");
              this.Property(t => t.Message).HasColumnName("Message").IsRequired();
              this.Property(t => t.Date).HasColumnName("Date");
              this.Property(t => t.UserId).HasColumnName("UserId");
         }
    }
}
