using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Repositorios
{
    public class RepositorioShoppingLists : RepositorioBase
    {
        public RepositorioShoppingLists(EveShopping.Modelo.Models.EveShoppingContext contexto = null)
            : base(contexto)
        {
        }

        #region ShoppingList
        public eshShoppingList SelectShopingListPorPublicID(string publicID)
        {            
            if (publicID == null)
            {
                throw new ApplicationException(Messages.err_publicIDNulo);
            }
            return this.Contexto.eshShoppingLists.Where(l => l.publicID == publicID).FirstOrDefault();
        }


        public eshFitting SelectFitPorID(int fittingID)
        {
            return Contexto.eshFittings.Include("invType").Include("eshFittingHardwares")
                .Include("eshFittingHardwares.invType").Where(f => f.fittingID == fittingID).FirstOrDefault();
        }


        public IEnumerable<eshFitting> SelectFitsEnShoppingList(string publicID)
        {
            var salida =
                (from sl in Contexto.eshShoppingLists
                 join slf in Contexto.eshShoppingListsFittings on sl.shoppingListID equals slf.shoppingListID
                 join f in Contexto.eshFittings.Include("eshFittingHardwares").Include("invType").Include("eshFittingHardwares.invType") on slf.fittingID equals f.fittingID
                 where sl.publicID == publicID
                 select f).ToList();

            return salida;
        }


        public void CrearShoppingList(eshShoppingList lista)
        {
            lista.dateCreation = System.DateTime.Now;
            lista.dateUpdate = System.DateTime.Now;

            this.Contexto.eshShoppingLists.Add(lista);
            this.Contexto.SaveChanges();
        }

        #endregion

        public void CrearFitting(eshFitting fit)
        {
            fit.dateCreation = System.DateTime.Now;            
            this.Contexto.eshFittings.Add(fit);
            this.Contexto.SaveChanges();
        }


    }
}
