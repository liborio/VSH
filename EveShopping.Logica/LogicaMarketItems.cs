﻿using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo;
using EveShopping.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica
{
    public class LogicaMarketItems
    {

        public IList<invMarketGroup> GetParentGroupsChain(int idGroup, int topGroupId = -1)
        {
            RepositorioItems repo = new RepositorioItems();
            return repo.GetParentGroupsChainStartingTop(idGroup, topGroupId);
        }

        public IEnumerable<invMarketGroup> SelectMarketGroupsByParentID(int? parentID)
        {
            RepositorioItems repo = new RepositorioItems();
            return repo.SelectMarketGroupsByParentID(parentID);
        }

        public IEnumerable<invType> SearchMarketItems(string searchText, int count = 50)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            return contexto.invTypes.Where(p => p.marketGroupID != null && p.typeName.Contains(searchText)).OrderBy(p => p.typeName).Take(count);
        }

        public IEnumerable<invType> SelectInvTypesByGroupID(int parentID)
        {
            RepositorioItems repo = new RepositorioItems();
            return repo.SelectInvTypeByGroupID(parentID);
        }



    }
}
