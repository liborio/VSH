//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EveShopping.Modelo
{
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    
    public partial class eshEveAccountUser
    {
        public int accountUserID { get; set; }
        public int accountID { get; set; }
        public string name { get; set; }
        public string corpName { get; set; }
        public string corpTicker { get; set; }
    
        public virtual eshEveAccount eshEveAccount { get; set; }
    }
}
