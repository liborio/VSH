using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica
{
    public class LogicaAdmin
    {
        public void FillShipGroupsTable()
        {
            IDictionary<int, IList<int>> dicc = CreateShipGroupsDictionary();
            EveShoppingContext contexto = new EveShoppingContext();

            foreach (var item in dicc)
            {
                invType it = contexto.invTypes.Where(i => i.typeID == item.Key).FirstOrDefault();
                IEnumerable<invMarketGroup> groups = contexto.invMarketGroups.Where(img => item.Value.Contains(img.marketGroupID));
                
                
                foreach (var g in groups)
                {
                    eshShipsMarketGroup smg = new eshShipsMarketGroup()
                    {
                        typeID = it.typeID,
                        marketGroupID = g.marketGroupID
                    };
                    contexto.eshShipsMarketGroups.Add(smg);
                }
            }
            contexto.SaveChanges();
        }

        #region "Auxiliares"

        private IDictionary<int, IList<int>> CreateShipGroupsDictionary(int initialGroupId = 4)
        {

            TreeNode<int> tree = new TreeNode<int>();
            tree.Value = initialGroupId;

            List<TreeNode<int>> finalNodeList = new List<TreeNode<int>>();


            FillNextLevel(tree, finalNodeList);

            List<int> finalNodeIdList = new List<int>();
            foreach (var item in finalNodeList)
            {
                finalNodeIdList.Add(item.Value);
            }


            EveShoppingContext contexto = new EveShoppingContext();
            var query = (from it in contexto.invTypes
                         where finalNodeIdList.Contains(it.marketGroupID.Value)
                         select it).ToList();


            Dictionary<int, IList<int>> dicc = new Dictionary<int, IList<int>>();

            foreach (var item in query)
            {
                IList<int> listaGroups = GetListOfGroupsToTop(item, finalNodeList);
                dicc.Add(item.typeID, listaGroups);
            }

            return dicc;

        }

        private IList<int> GetListOfGroupsToTop(invType item, List<TreeNode<int>> finalNodeList)
        {
            TreeNode<int> nodoFinal = finalNodeList.Where(n => n.Value == item.marketGroupID.Value).FirstOrDefault(); ;
            List<int> listaNodos = new List<int>();
            listaNodos.Add(nodoFinal.Value);
            while (nodoFinal.Parent != null)
            {
                nodoFinal = nodoFinal.Parent;
                listaNodos.Add(nodoFinal.Value);
            }
            return listaNodos;
        }

        private void FillNextLevel(TreeNode<int> node, List<TreeNode<int>> finalNodeList)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            var query = from img in contexto.invMarketGroups
                        where img.parentGroupID == node.Value
                        orderby img.marketGroupName
                        select img;

            foreach (var item in query)
            {
                TreeNode<int> tree = new TreeNode<int>();
                tree.Value = item.marketGroupID;
                tree.Parent = node;
                node.Descendants.Add(tree);
                FillNextLevel(tree, finalNodeList);
            }

            if (query.Count() == 0)
            {
                finalNodeList.Add(node);
            }

        }

        #endregion
    }
}
