using EveShopping.Logica;
using EveShopping.Modelo.EV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Agentes
{
    public class AgenteGroupLists
    {
        public string CreateGroupList(string userName, string name, string description)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.CreateGroupList(userName, name, description);
        }

        public void DeleteList(string userName, string publicID)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            logica.DeleteGroupList(userName, publicID);
        }

        public IList<EVShoppingListHeader> SelectGroupListsByUserName(string userName)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.SelectGroupListsByUserName(userName);
        }

    }
}
