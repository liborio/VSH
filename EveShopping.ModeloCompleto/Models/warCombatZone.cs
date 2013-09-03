using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class warCombatZone
    {
        public int combatZoneID { get; set; }
        public string combatZoneName { get; set; }
        public Nullable<int> factionID { get; set; }
        public Nullable<int> centerSystemID { get; set; }
        public string description { get; set; }
    }
}
