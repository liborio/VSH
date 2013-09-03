using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class chrAncestry
    {
        public byte ancestryID { get; set; }
        public string ancestryName { get; set; }
        public Nullable<byte> bloodlineID { get; set; }
        public string description { get; set; }
        public Nullable<byte> perception { get; set; }
        public Nullable<byte> willpower { get; set; }
        public Nullable<byte> charisma { get; set; }
        public Nullable<byte> memory { get; set; }
        public Nullable<byte> intelligence { get; set; }
        public Nullable<int> iconID { get; set; }
        public string shortDescription { get; set; }
    }
}
