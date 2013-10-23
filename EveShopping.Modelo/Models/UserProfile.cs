using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.eshFittings = new List<eshFitting>();
            this.eshGroupShoppingLists = new List<eshGroupShoppingList>();
            this.eshShoppingLists = new List<eshShoppingList>();
            this.webpages_Roles = new List<webpages_Roles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<eshFitting> eshFittings { get; set; }
        public virtual ICollection<eshGroupShoppingList> eshGroupShoppingLists { get; set; }
        public virtual ICollection<eshShoppingList> eshShoppingLists { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
