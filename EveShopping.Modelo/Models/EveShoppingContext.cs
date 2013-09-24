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
        public DbSet<eshShoppingListFitting> eshShoppingListsFittings { get; set; }
        public DbSet<eshShoppingListInvType> eshShoppingListsInvTypes { get; set; }
        public DbSet<eshPrice> eshPrices { get; set; }
        public DbSet<eshTradeHub> eshTradeHubs { get; set; }
        public DbSet<invType> invTypes { get; set; }
        public DbSet<invMarketGroup> invMarketGroups { get; set; }
        //public DbSet<staStation> staStations { get; set; }
        public DbSet<mapSolarSystem> mapSolarSystems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new eshFittingHardwareMap());
            modelBuilder.Configurations.Add(new eshFittingMap());
            modelBuilder.Configurations.Add(new eshFittingSlotMap());
            modelBuilder.Configurations.Add(new eshShoppingListMap());
            modelBuilder.Configurations.Add(new eshShoppingListFittingMap());
            modelBuilder.Configurations.Add(new eshShoppingListInvTypeMap());
            modelBuilder.Configurations.Add(new eshPriceMap());
            modelBuilder.Configurations.Add(new eshTradeHubMap());
            modelBuilder.Configurations.Add(new invTypeMap());
            modelBuilder.Configurations.Add(new invMarketGroupMap());
            //modelBuilder.Configurations.Add(new staStationMap());
            modelBuilder.Configurations.Add(new mapSolarSystemMap());
        }
    }
}
