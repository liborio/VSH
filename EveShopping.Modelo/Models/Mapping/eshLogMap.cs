using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EveShopping.Modelo.Models.Mapping
{
    public class eshLogMap : EntityTypeConfiguration<eshLog>
    {
        public eshLogMap()
        {
            // Primary Key
            this.HasKey(t => t.LogID);

            // Properties
            this.Property(t => t.Message)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("eshLogs");
            this.Property(t => t.LogID).HasColumnName("LogID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Severity).HasColumnName("Severity");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
