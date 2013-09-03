using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class invBlueprintType
    {
        public int blueprintTypeID { get; set; }
        public Nullable<int> parentBlueprintTypeID { get; set; }
        public Nullable<int> productTypeID { get; set; }
        public Nullable<int> productionTime { get; set; }
        public Nullable<short> techLevel { get; set; }
        public Nullable<int> researchProductivityTime { get; set; }
        public Nullable<int> researchMaterialTime { get; set; }
        public Nullable<int> researchCopyTime { get; set; }
        public Nullable<int> researchTechTime { get; set; }
        public Nullable<int> productivityModifier { get; set; }
        public Nullable<short> materialModifier { get; set; }
        public Nullable<short> wasteFactor { get; set; }
        public Nullable<int> maxProductionLimit { get; set; }
    }
}
