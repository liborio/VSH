using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class staOperation
    {
        public Nullable<byte> activityID { get; set; }
        public byte operationID { get; set; }
        public string operationName { get; set; }
        public string description { get; set; }
        public Nullable<byte> fringe { get; set; }
        public Nullable<byte> corridor { get; set; }
        public Nullable<byte> hub { get; set; }
        public Nullable<byte> border { get; set; }
        public Nullable<byte> ratio { get; set; }
        public Nullable<int> caldariStationTypeID { get; set; }
        public Nullable<int> minmatarStationTypeID { get; set; }
        public Nullable<int> amarrStationTypeID { get; set; }
        public Nullable<int> gallenteStationTypeID { get; set; }
        public Nullable<int> joveStationTypeID { get; set; }
    }
}
