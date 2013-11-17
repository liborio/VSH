﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#pragma warning disable 1573
namespace EveShopping.Modelo
{
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EveShoppingContext : DbContext
    {
        static EveShoppingContext()
    	{ 
    		Database.SetInitializer<EveShoppingContext>(null);
    	}
    	
    	public EveShoppingContext() : base("name=EveShoppingContext")
        {
        }
    	
    	public EveShoppingContext(string nameOrConnectionString) : base(nameOrConnectionString)
    	{	
    	}
    
    	public EveShoppingContext(string nameOrConnectionString, DbCompiledModel model) : base(nameOrConnectionString, model)
    	{
    	}
    
    	public EveShoppingContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
    	{
    	}
    
    	public EveShoppingContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection)
    	{
    	}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {		
    		modelBuilder.Configurations.Add(new dgmEffect_Mapping());
    		modelBuilder.Configurations.Add(new dgmTypeEffect_Mapping());
    		modelBuilder.Configurations.Add(new eshChangeLog_Mapping());
    		modelBuilder.Configurations.Add(new eshEveAccount_Mapping());
    		modelBuilder.Configurations.Add(new eshEveAccountCharacter_Mapping());
    		modelBuilder.Configurations.Add(new eshFitting_Mapping());
    		modelBuilder.Configurations.Add(new eshFittingHardware_Mapping());
    		modelBuilder.Configurations.Add(new eshFittingSlot_Mapping());
    		modelBuilder.Configurations.Add(new eshGroupShoppingList_Mapping());
    		modelBuilder.Configurations.Add(new eshGroupShoppingListSnapshot_Mapping());
    		modelBuilder.Configurations.Add(new eshLog_Mapping());
    		modelBuilder.Configurations.Add(new eshPrice_Mapping());
    		modelBuilder.Configurations.Add(new eshShipsMarketGroup_Mapping());
    		modelBuilder.Configurations.Add(new eshShoppingList_Mapping());
    		modelBuilder.Configurations.Add(new eshShoppingListFitting_Mapping());
    		modelBuilder.Configurations.Add(new eshShoppingListInvType_Mapping());
    		modelBuilder.Configurations.Add(new eshShoppingListSummInvType_Mapping());
    		modelBuilder.Configurations.Add(new eshSnapshot_Mapping());
    		modelBuilder.Configurations.Add(new eshSnapshotInvType_Mapping());
    		modelBuilder.Configurations.Add(new eshTinyUrlMapping_Mapping());
    		modelBuilder.Configurations.Add(new eshTradeHub_Mapping());
    		modelBuilder.Configurations.Add(new invGroup_Mapping());
    		modelBuilder.Configurations.Add(new invMarketGroup_Mapping());
    		modelBuilder.Configurations.Add(new invType_Mapping());
    		modelBuilder.Configurations.Add(new mapSolarSystem_Mapping());
    		modelBuilder.Configurations.Add(new UserProfile_Mapping());
    		modelBuilder.Configurations.Add(new webpages_Roles_Mapping());
        }
    	
        public DbSet<dgmEffect> dgmEffects { get; set; }
        public DbSet<dgmTypeEffect> dgmTypeEffects { get; set; }
        public DbSet<eshChangeLog> eshChangeLogs { get; set; }
        public DbSet<eshFittingHardware> eshFittingHardwares { get; set; }
        public DbSet<eshFitting> eshFittings { get; set; }
        public DbSet<eshFittingSlot> eshFittingSlots { get; set; }
        public DbSet<eshGroupShoppingList> eshGroupShoppingLists { get; set; }
        public DbSet<eshGroupShoppingListSnapshot> eshGroupShoppingListSnapshots { get; set; }
        public DbSet<eshLog> eshLogs { get; set; }
        public DbSet<eshPrice> eshPrices { get; set; }
        public DbSet<eshShipsMarketGroup> eshShipsMarketGroups { get; set; }
        public DbSet<eshShoppingListFitting> eshShoppingListFittings { get; set; }
        public DbSet<eshShoppingListInvType> eshShoppingListInvTypes { get; set; }
        public DbSet<eshShoppingList> eshShoppingLists { get; set; }
        public DbSet<eshShoppingListSummInvType> eshShoppingListSummInvTypes { get; set; }
        public DbSet<eshSnapshot> eshSnapshots { get; set; }
        public DbSet<eshSnapshotInvType> eshSnapshotInvTypes { get; set; }
        public DbSet<eshTinyUrlMapping> eshTinyUrlMappings { get; set; }
        public DbSet<eshTradeHub> eshTradeHubs { get; set; }
        public DbSet<invGroup> invGroups { get; set; }
        public DbSet<invMarketGroup> invMarketGroups { get; set; }
        public DbSet<invType> invTypes { get; set; }
        public DbSet<mapSolarSystem> mapSolarSystems { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public DbSet<eshEveAccount> eshEveAccounts { get; set; }
        public DbSet<eshEveAccountCharacter> eshEveAccountCharacters { get; set; }
    }
}
