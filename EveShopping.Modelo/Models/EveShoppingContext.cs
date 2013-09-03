using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EveShopping.Modelo.Models.Mapping;
using EveShopping.Modelo.Models;

namespace EveShopping.Modelo.Models
{
    public partial class EveShoppingContext : DbContext
    {
        static EveShoppingContext()
        {
            Database.SetInitializer<EveShoppingContext>(null);
        }

        public EveShoppingContext()
            : base("Name=EveShoppingContext")
        {
        }

        public DbSet<eshFittingHardware> eshFittingHardwares { get; set; }
        public DbSet<eshFitting> eshFittings { get; set; }
        public DbSet<eshFittingSlot> eshFittingSlots { get; set; }
        public DbSet<eshShoppingList> eshShoppingLists { get; set; }
        public DbSet<invType> invTypes { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new eshFittingHardwareMap());
            modelBuilder.Configurations.Add(new eshFittingMap());
            modelBuilder.Configurations.Add(new eshFittingSlotMap());
            modelBuilder.Configurations.Add(new eshShoppingListMap());
            modelBuilder.Configurations.Add(new invTypeMap());
        }
    }
}
