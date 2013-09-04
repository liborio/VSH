﻿using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.Models;
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

        public IList<invMarketGroup> GetParentGroupsChain(int idGroup)
        {
            RepositorioItems repo = new RepositorioItems();
            return repo.GetParentGroupsChainStartingTop(idGroup);
        }

        public IEnumerable<invMarketGroup> SelectMarketGroupsByParentID(int? parentID)
        {
            RepositorioItems repo = new RepositorioItems();
            return repo.SelectMarketGroupsByParentID(parentID);
        }

        public IEnumerable<invType> SelectInvTypesByGroupID(int parentID)
        {
            RepositorioItems repo = new RepositorioItems();
            return repo.SelectInvTypeByGroupID(parentID);
        }



    }
}