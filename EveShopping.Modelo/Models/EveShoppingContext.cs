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
        public DbSet<eshShoppingListSummInvType> eshShoppingListSummInvTypes { get; set; }
        public DbSet<eshPrice> eshPrices { get; set; }
        public DbSet<eshTradeHub> eshTradeHubs { get; set; }
        public DbSet<eshSnapshot> eshSnapshots { get; set; }
        public DbSet<eshSnapshotInvType> eshSnapshotInvTypes { get; set; }
        public DbSet<eshShipsMarketGroup> eshShipsMarketGroups { get; set; }
        public DbSet<eshLog> eshLogs { get; set; }
        public DbSet<eshGroupShoppingList> eshGroupShoppingLists { get; set; }
        public DbSet<eshGroupShoppingListSnapshot> eshGroupShoppingListSnapshots { get; set; }

        public DbSet<dgmEffect> dmgEffects { get; set; }
        public DbSet<dgmTypeEffect> dmgTypeEffects { get; set; }
        public DbSet<invType> invTypes { get; set; }
        public DbSet<invMarketGroup> invMarketGroups { get; set; }
        public DbSet<invGroup> invGroups { get; set; }
        public DbSet<UserProfile> userProfiles { get; set; }
        public DbSet<webpages_Roles> webPageRoles { get; set; }
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
            modelBuilder.Configurations.Add(new eshShoppingListSummInvTypeMap());
            modelBuilder.Configurations.Add(new eshPriceMap());
            modelBuilder.Configurations.Add(new eshTradeHubMap());
            modelBuilder.Configurations.Add(new eshSnapshotMap());
            modelBuilder.Configurations.Add(new eshSnapshotInvTypeMap());
            modelBuilder.Configurations.Add(new eshShipsMarketGroupMap());
            modelBuilder.Configurations.Add(new eshLogMap());
            modelBuilder.Configurations.Add(new eshGroupShoppingListMap());
            modelBuilder.Configurations.Add(new eshGroupShoppingListSnapshotMap());
            modelBuilder.Configurations.Add(new dgmEffectMap());
            modelBuilder.Configurations.Add(new dgmTypeEffectMap());
            modelBuilder.Configurations.Add(new invTypeMap());
            modelBuilder.Configurations.Add(new invMarketGroupMap());
            modelBuilder.Configurations.Add(new invGroupMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new webpages_RolesMap());
            //modelBuilder.Configurations.Add(new staStationMap());
            modelBuilder.Configurations.Add(new mapSolarSystemMap());
        }
    }
}
