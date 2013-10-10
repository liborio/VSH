using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EveShopping.Modelo.Models.Mapping;

namespace EveShopping.Modelo.Models
{
    public partial class EveShopping_1_1Context : DbContext
    {
        static EveShopping_1_1Context()
        {
            Database.SetInitializer<EveShopping_1_1Context>(null);
        }

        public EveShopping_1_1Context()
            : base("Name=EveShopping_1_1Context")
        {
        }

        public DbSet<agtAgent> agtAgents { get; set; }
        public DbSet<agtAgentType> agtAgentTypes { get; set; }
        public DbSet<agtResearchAgent> agtResearchAgents { get; set; }
        public DbSet<chrAncestry> chrAncestries { get; set; }
        public DbSet<chrAttribute> chrAttributes { get; set; }
        public DbSet<chrBloodline> chrBloodlines { get; set; }
        public DbSet<chrFaction> chrFactions { get; set; }
        public DbSet<chrRace> chrRaces { get; set; }
        public DbSet<crpActivity> crpActivities { get; set; }
        public DbSet<crpNPCCorporationDivision> crpNPCCorporationDivisions { get; set; }
        public DbSet<crpNPCCorporationResearchField> crpNPCCorporationResearchFields { get; set; }
        public DbSet<crpNPCCorporation> crpNPCCorporations { get; set; }
        public DbSet<crpNPCCorporationTrade> crpNPCCorporationTrades { get; set; }
        public DbSet<crpNPCDivision> crpNPCDivisions { get; set; }
        public DbSet<crtCategory> crtCategories { get; set; }
        public DbSet<crtCertificate> crtCertificates { get; set; }
        public DbSet<crtClass> crtClasses { get; set; }
        public DbSet<crtRecommendation> crtRecommendations { get; set; }
        public DbSet<crtRelationship> crtRelationships { get; set; }
        public DbSet<dgmAttributeCategory> dgmAttributeCategories { get; set; }
        public DbSet<dgmAttributeType> dgmAttributeTypes { get; set; }
        public DbSet<dgmEffect> dgmEffects { get; set; }
        public DbSet<dgmTypeAttribute> dgmTypeAttributes { get; set; }
        public DbSet<dgmTypeEffect> dgmTypeEffects { get; set; }
        public DbSet<eshFittingHardware> eshFittingHardwares { get; set; }
        public DbSet<eshFitting> eshFittings { get; set; }
        public DbSet<eshFittingSlot> eshFittingSlots { get; set; }
        public DbSet<eshPrice> eshPrices { get; set; }
        public DbSet<eshShipsMarketGroup> eshShipsMarketGroups { get; set; }
        public DbSet<eshShoppingListFitting> eshShoppingListFittings { get; set; }
        public DbSet<eshShoppingListInvType> eshShoppingListInvTypes { get; set; }
        public DbSet<eshShoppingList> eshShoppingLists { get; set; }
        public DbSet<eshShoppingListSummInvType> eshShoppingListSummInvTypes { get; set; }
        public DbSet<eshSnapshot> eshSnapshots { get; set; }
        public DbSet<eshSnapshotInvType> eshSnapshotInvTypes { get; set; }
        public DbSet<eshTradeHub> eshTradeHubs { get; set; }
        public DbSet<eveUnit> eveUnits { get; set; }
        public DbSet<invBlueprintType> invBlueprintTypes { get; set; }
        public DbSet<invCategory> invCategories { get; set; }
        public DbSet<invContrabandType> invContrabandTypes { get; set; }
        public DbSet<invControlTowerResourcePurpos> invControlTowerResourcePurposes { get; set; }
        public DbSet<invControlTowerResource> invControlTowerResources { get; set; }
        public DbSet<invFlag> invFlags { get; set; }
        public DbSet<invGroup> invGroups { get; set; }
        public DbSet<invItem> invItems { get; set; }
        public DbSet<invMarketGroup> invMarketGroups { get; set; }
        public DbSet<invMetaGroup> invMetaGroups { get; set; }
        public DbSet<invMetaType> invMetaTypes { get; set; }
        public DbSet<invName> invNames { get; set; }
        public DbSet<invPosition> invPositions { get; set; }
        public DbSet<invTypeMaterial> invTypeMaterials { get; set; }
        public DbSet<invTypeReaction> invTypeReactions { get; set; }
        public DbSet<invType> invTypes { get; set; }
        public DbSet<invUniqueName> invUniqueNames { get; set; }
        public DbSet<mapCelestialStatistic> mapCelestialStatistics { get; set; }
        public DbSet<mapConstellationJump> mapConstellationJumps { get; set; }
        public DbSet<mapConstellation> mapConstellations { get; set; }
        public DbSet<mapDenormalize> mapDenormalizes { get; set; }
        public DbSet<mapJump> mapJumps { get; set; }
        public DbSet<mapLandmark> mapLandmarks { get; set; }
        public DbSet<mapLocationScene> mapLocationScenes { get; set; }
        public DbSet<mapLocationWormholeClass> mapLocationWormholeClasses { get; set; }
        public DbSet<mapRegionJump> mapRegionJumps { get; set; }
        public DbSet<mapRegion> mapRegions { get; set; }
        public DbSet<mapSolarSystemJump> mapSolarSystemJumps { get; set; }
        public DbSet<mapSolarSystem> mapSolarSystems { get; set; }
        public DbSet<mapUniverse> mapUniverses { get; set; }
        public DbSet<planetSchematic> planetSchematics { get; set; }
        public DbSet<planetSchematicsPinMap> planetSchematicsPinMaps { get; set; }
        public DbSet<planetSchematicsTypeMap> planetSchematicsTypeMaps { get; set; }
        public DbSet<ramActivity> ramActivities { get; set; }
        public DbSet<ramAssemblyLine> ramAssemblyLines { get; set; }
        public DbSet<ramAssemblyLineStation> ramAssemblyLineStations { get; set; }
        public DbSet<ramAssemblyLineTypeDetailPerCategory> ramAssemblyLineTypeDetailPerCategories { get; set; }
        public DbSet<ramAssemblyLineTypeDetailPerGroup> ramAssemblyLineTypeDetailPerGroups { get; set; }
        public DbSet<ramAssemblyLineType> ramAssemblyLineTypes { get; set; }
        public DbSet<ramInstallationTypeContent> ramInstallationTypeContents { get; set; }
        public DbSet<ramTypeRequirement> ramTypeRequirements { get; set; }
        public DbSet<staOperation> staOperations { get; set; }
        public DbSet<staOperationService> staOperationServices { get; set; }
        public DbSet<staService> staServices { get; set; }
        public DbSet<staStation> staStations { get; set; }
        public DbSet<staStationType> staStationTypes { get; set; }
        public DbSet<trnTranslationColumn> trnTranslationColumns { get; set; }
        public DbSet<trnTranslationLanguage> trnTranslationLanguages { get; set; }
        public DbSet<trnTranslation> trnTranslations { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<warCombatZone> warCombatZones { get; set; }
        public DbSet<warCombatZoneSystem> warCombatZoneSystems { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new agtAgentMap());
            modelBuilder.Configurations.Add(new agtAgentTypeMap());
            modelBuilder.Configurations.Add(new agtResearchAgentMap());
            modelBuilder.Configurations.Add(new chrAncestryMap());
            modelBuilder.Configurations.Add(new chrAttributeMap());
            modelBuilder.Configurations.Add(new chrBloodlineMap());
            modelBuilder.Configurations.Add(new chrFactionMap());
            modelBuilder.Configurations.Add(new chrRaceMap());
            modelBuilder.Configurations.Add(new crpActivityMap());
            modelBuilder.Configurations.Add(new crpNPCCorporationDivisionMap());
            modelBuilder.Configurations.Add(new crpNPCCorporationResearchFieldMap());
            modelBuilder.Configurations.Add(new crpNPCCorporationMap());
            modelBuilder.Configurations.Add(new crpNPCCorporationTradeMap());
            modelBuilder.Configurations.Add(new crpNPCDivisionMap());
            modelBuilder.Configurations.Add(new crtCategoryMap());
            modelBuilder.Configurations.Add(new crtCertificateMap());
            modelBuilder.Configurations.Add(new crtClassMap());
            modelBuilder.Configurations.Add(new crtRecommendationMap());
            modelBuilder.Configurations.Add(new crtRelationshipMap());
            modelBuilder.Configurations.Add(new dgmAttributeCategoryMap());
            modelBuilder.Configurations.Add(new dgmAttributeTypeMap());
            modelBuilder.Configurations.Add(new dgmEffectMap());
            modelBuilder.Configurations.Add(new dgmTypeAttributeMap());
            modelBuilder.Configurations.Add(new dgmTypeEffectMap());
            modelBuilder.Configurations.Add(new eshFittingHardwareMap());
            modelBuilder.Configurations.Add(new eshFittingMap());
            modelBuilder.Configurations.Add(new eshFittingSlotMap());
            modelBuilder.Configurations.Add(new eshPriceMap());
            modelBuilder.Configurations.Add(new eshShipsMarketGroupMap());
            modelBuilder.Configurations.Add(new eshShoppingListFittingMap());
            modelBuilder.Configurations.Add(new eshShoppingListInvTypeMap());
            modelBuilder.Configurations.Add(new eshShoppingListMap());
            modelBuilder.Configurations.Add(new eshShoppingListSummInvTypeMap());
            modelBuilder.Configurations.Add(new eshSnapshotMap());
            modelBuilder.Configurations.Add(new eshSnapshotInvTypeMap());
            modelBuilder.Configurations.Add(new eshTradeHubMap());
            modelBuilder.Configurations.Add(new eveUnitMap());
            modelBuilder.Configurations.Add(new invBlueprintTypeMap());
            modelBuilder.Configurations.Add(new invCategoryMap());
            modelBuilder.Configurations.Add(new invContrabandTypeMap());
            modelBuilder.Configurations.Add(new invControlTowerResourcePurposMap());
            modelBuilder.Configurations.Add(new invControlTowerResourceMap());
            modelBuilder.Configurations.Add(new invFlagMap());
            modelBuilder.Configurations.Add(new invGroupMap());
            modelBuilder.Configurations.Add(new invItemMap());
            modelBuilder.Configurations.Add(new invMarketGroupMap());
            modelBuilder.Configurations.Add(new invMetaGroupMap());
            modelBuilder.Configurations.Add(new invMetaTypeMap());
            modelBuilder.Configurations.Add(new invNameMap());
            modelBuilder.Configurations.Add(new invPositionMap());
            modelBuilder.Configurations.Add(new invTypeMaterialMap());
            modelBuilder.Configurations.Add(new invTypeReactionMap());
            modelBuilder.Configurations.Add(new invTypeMap());
            modelBuilder.Configurations.Add(new invUniqueNameMap());
            modelBuilder.Configurations.Add(new mapCelestialStatisticMap());
            modelBuilder.Configurations.Add(new mapConstellationJumpMap());
            modelBuilder.Configurations.Add(new mapConstellationMap());
            modelBuilder.Configurations.Add(new mapDenormalizeMap());
            modelBuilder.Configurations.Add(new mapJumpMap());
            modelBuilder.Configurations.Add(new mapLandmarkMap());
            modelBuilder.Configurations.Add(new mapLocationSceneMap());
            modelBuilder.Configurations.Add(new mapLocationWormholeClassMap());
            modelBuilder.Configurations.Add(new mapRegionJumpMap());
            modelBuilder.Configurations.Add(new mapRegionMap());
            modelBuilder.Configurations.Add(new mapSolarSystemJumpMap());
            modelBuilder.Configurations.Add(new mapSolarSystemMap());
            modelBuilder.Configurations.Add(new mapUniverseMap());
            modelBuilder.Configurations.Add(new planetSchematicMap());
            modelBuilder.Configurations.Add(new planetSchematicsPinMapMap());
            modelBuilder.Configurations.Add(new planetSchematicsTypeMapMap());
            modelBuilder.Configurations.Add(new ramActivityMap());
            modelBuilder.Configurations.Add(new ramAssemblyLineMap());
            modelBuilder.Configurations.Add(new ramAssemblyLineStationMap());
            modelBuilder.Configurations.Add(new ramAssemblyLineTypeDetailPerCategoryMap());
            modelBuilder.Configurations.Add(new ramAssemblyLineTypeDetailPerGroupMap());
            modelBuilder.Configurations.Add(new ramAssemblyLineTypeMap());
            modelBuilder.Configurations.Add(new ramInstallationTypeContentMap());
            modelBuilder.Configurations.Add(new ramTypeRequirementMap());
            modelBuilder.Configurations.Add(new staOperationMap());
            modelBuilder.Configurations.Add(new staOperationServiceMap());
            modelBuilder.Configurations.Add(new staServiceMap());
            modelBuilder.Configurations.Add(new staStationMap());
            modelBuilder.Configurations.Add(new staStationTypeMap());
            modelBuilder.Configurations.Add(new trnTranslationColumnMap());
            modelBuilder.Configurations.Add(new trnTranslationLanguageMap());
            modelBuilder.Configurations.Add(new trnTranslationMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new warCombatZoneMap());
            modelBuilder.Configurations.Add(new warCombatZoneSystemMap());
            modelBuilder.Configurations.Add(new webpages_MembershipMap());
            modelBuilder.Configurations.Add(new webpages_OAuthMembershipMap());
            modelBuilder.Configurations.Add(new webpages_RolesMap());
        }
    }
}
