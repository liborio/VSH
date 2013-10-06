using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.eshShoppingLists = new List<eshShoppingList>();
            this.webpages_Roles = new List<webpages_Roles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<eshShoppingList> eshShoppingLists { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
