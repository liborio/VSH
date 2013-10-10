using EveShopping.Logica;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Agentes
{
    public class AgenteShared
    {
        public void SetMenuCounters(string userName, out int fittingCount, out int listCount)
        {
            LogicaShoppingLists logicaLists = new LogicaShoppingLists();
            LogicaFittings logicaFittings = new LogicaFittings();

            listCount = logicaLists.GetListCountByUser(userName);
            fittingCount = logicaFittings.GetFittingCountByUser(userName);

        }
    }
}
