using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class dgmEffect
    {
        public short effectID { get; set; }
        public string effectName { get; set; }
        public Nullable<short> effectCategory { get; set; }
        public Nullable<int> preExpression { get; set; }
        public Nullable<int> postExpression { get; set; }
        public string description { get; set; }
        public string guid { get; set; }
        public Nullable<int> iconID { get; set; }
        public Nullable<bool> isOffensive { get; set; }
        public Nullable<bool> isAssistance { get; set; }
        public Nullable<short> durationAttributeID { get; set; }
        public Nullable<short> trackingSpeedAttributeID { get; set; }
        public Nullable<short> dischargeAttributeID { get; set; }
        public Nullable<short> rangeAttributeID { get; set; }
        public Nullable<short> falloffAttributeID { get; set; }
        public Nullable<bool> disallowAutoRepeat { get; set; }
        public Nullable<bool> published { get; set; }
        public string displayName { get; set; }
        public Nullable<bool> isWarpSafe { get; set; }
        public Nullable<bool> rangeChance { get; set; }
        public Nullable<bool> electronicChance { get; set; }
        public Nullable<bool> propulsionChance { get; set; }
        public Nullable<byte> distribution { get; set; }
        public string sfxName { get; set; }
        public Nullable<short> npcUsageChanceAttributeID { get; set; }
        public Nullable<short> npcActivationChanceAttributeID { get; set; }
        public Nullable<short> fittingUsageChanceAttributeID { get; set; }
    }
}
