using EveShopping.Logica;
using EveShopping.Modelo.Models;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Agentes
{
    public class AgenteMarketItems
    {
        public IList<invMarketGroup> GetParentGroupsChain(int idGroup)
        {
            LogicaMarketItems logica = new LogicaMarketItems();

            IList<invMarketGroup> salida = logica.GetParentGroupsChain(idGroup);
            salida.Insert(0, new invMarketGroup{ parentGroupID=-1, marketGroupName="Root"});

            return salida;
        }



        public IEnumerable<EVMarketItem> SearchMarketItems(string searchText){
            LogicaMarketItems logica = new LogicaMarketItems();
            IEnumerable<invType> invTypes = logica.SearchMarketItems(searchText);

            foreach (var item in invTypes)
            {
                yield return Copiar(item);
            }

        }



        public IEnumerable<EVMarketItem> SelectMarketGroupsByParentID(int? parentID)
        {
            if (parentID == 0)
            {
                parentID = null;
            }
            LogicaMarketItems logica = new LogicaMarketItems();
            IEnumerable<invMarketGroup> groups = logica.SelectMarketGroupsByParentID(parentID);
            IEnumerable<invType> tipos = null;
            if (parentID.HasValue)
            {
                tipos = logica.SelectInvTypesByGroupID(parentID.Value);
            }
            IList<EVMarketItem> lista = new List<EVMarketItem>();
            if (groups != null)
            {
                foreach (var item in groups)
                {
                    lista.Add(Copiar(item));
                }
            }
            if (tipos != null)
            {
                foreach (var item in tipos)
                {
                    lista.Add(Copiar(item));
                }
            }
            return lista;
        }

        private EVMarketItem Copiar(invMarketGroup inv)
        {
            EVMarketItem mi = new EVMarketItem();
            mi.ItemID = inv.marketGroupID;
            mi.ParentID = inv.parentGroupID;
            mi.Name = inv.marketGroupName;
            mi.UrlIcon = null;           
            mi.EsFinal = false;
            return mi;
        }

        private EVMarketItem Copiar(invType inv)
        {
            EVMarketItem mi = new EVMarketItem();
            mi.ItemID = inv.typeID;
            mi.ParentID = inv.marketGroupID;
            mi.Name = inv.typeName;
            mi.UrlIcon = string.Format("http://image.eveonline.com/Type/{0}_32.png", inv.typeID);
            mi.EsFinal = true;
            return mi;
        }
    }
}
