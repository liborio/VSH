using EveShopping.Logica;
using EveShopping.Modelo.EV;
using EveShopping.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Agentes
{
    public class AgenteFittings
    {

        public void DeleteFitting(int id, string userName)
        {
            LogicaFittings logica = new LogicaFittings();
            logica.DeleteFitting(id, userName);
        }

        public IEnumerable<ShipMarketGroup> SelectMarketGroupsByParentID(int parentID, string userName)
        {
            LogicaFittings logica = new LogicaFittings();
            return logica.SelectMarketGroupsByParentID(parentID, userName);
        }

        public IList<invMarketGroup> GetParentGroupsChainForShips(int idGroup)
        {
            LogicaMarketItems logica = new LogicaMarketItems();

            IList<invMarketGroup> salida = logica.GetParentGroupsChain(idGroup, 4);
            salida.Insert(0, new invMarketGroup { parentGroupID = -1, marketGroupID = 4, marketGroupName = "Ships" });

            return salida;
        }

        public EVFitting SelectFitByPublicID(string publicID)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            return logica.SelectFitSummaryByPublicID(publicID, new Imagex32UrlResolver(), 30000142);
        }

        public IEnumerable<EVFitting> SelectFitsByMarketGroup(string userName, int marketGroupID)
        {
            LogicaFittings logica = new LogicaFittings();
            return logica.SelectFitsByMarketGroup(userName, marketGroupID, new Imagex32UrlResolver(), 30000142);
        }

        public int GetFitMarketGroupID(int fitID)
        {
            LogicaFittings logica = new LogicaFittings();
            return logica.GetFitMarketGroupID(fitID);
        }
    }
}
