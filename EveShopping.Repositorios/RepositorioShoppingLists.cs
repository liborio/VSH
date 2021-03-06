﻿using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Repositorios
{
    public class RepositorioShoppingLists : RepositorioBase
    {
        public RepositorioShoppingLists(EveShopping.Modelo.EveShoppingContext contexto = null)
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

        public eshShoppingListInvType SelectMarketItemEnShoppingListPorID(int listID, int itemID)
        {

            return Contexto.eshShoppingListInvTypes.Where(slit => slit.shoppingListID == listID && slit.typeID == itemID).FirstOrDefault();
        }

        public eshShoppingListInvType CreateMarketItemEnShoppingList(int listID, int itemID, int units)
        {
            eshShoppingListInvType slit = new eshShoppingListInvType();
            slit.typeID = itemID;
            slit.shoppingListID = listID;
            slit.units = units;

            invType it = Contexto.invTypes.Where(it2 => it2.typeID == itemID).FirstOrDefault();
            if (it == null)
            {
                throw new ApplicationException(Messages.err_itemNoExiste);
            }
            RepositorioItems repoItems = new RepositorioItems();
            slit.volume = units * RepositorioItems.GetVolume(it);
            Contexto.eshShoppingListInvTypes.Add(slit);
            Contexto.SaveChanges();
            return slit;
        }

        public eshShoppingListInvType UpdateMarketItemEnShoppingList(int listID, int itemID, int units)
        {
            eshShoppingListInvType slit = SelectMarketItemEnShoppingListPorID(listID, itemID);

            if (slit == null)
            {
                CreateMarketItemEnShoppingList(listID, itemID, units);
            }
            else
            {
                invType it = Contexto.invTypes.Where(it2 => it2.typeID == itemID).FirstOrDefault();
                if (it == null)
                {
                    throw new ApplicationException(Messages.err_itemNoExiste);
                }
                slit.units = units;
                if (slit.units < 0) slit.units = 0;


                RepositorioItems repoItems = new RepositorioItems(this.Contexto);
                slit.volume = slit.units * RepositorioItems.GetVolume(it);
            }
            Contexto.SaveChanges();
            return slit;
        }

        public IEnumerable<eshShoppingListFitting> SelectFitsEnShoppingList(string publicID)
        {
            var salida =
                (from sl in Contexto.eshShoppingLists
                 join slf in Contexto.eshShoppingListFittings.Include("eshFitting.eshFittingHardwares").Include("eshFitting.invType").Include("eshFitting.eshFittingHardwares.invType") on sl.shoppingListID equals slf.shoppingListID
                 join f in Contexto.eshFittings on slf.fittingID equals f.fittingID
                 where sl.publicID == publicID
                 select slf).ToList();

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
            if (string.IsNullOrEmpty(fit.publicID)) { fit.publicID = Guid.NewGuid().ToString(); }
            fit.dateCreation = System.DateTime.Now;            
            this.Contexto.eshFittings.Add(fit);
            this.Contexto.SaveChanges();
        }

        public void ShoppingListUpdated(int id, EveShoppingContext context = null)
        {
            if (context == null)
            {
                context = new EveShoppingContext();
            }

            eshShoppingList sl = context.eshShoppingLists.Where(s => s.shoppingListID == id).FirstOrDefault();
            sl.dateUpdate = System.DateTime.Now;
            context.SaveChanges();


        }

        public void ShoppingListUpdated(string publicId, EveShoppingContext context = null)
        {
            if (context == null)
            {
                context = new EveShoppingContext();
            }
            eshShoppingList sl = context.eshShoppingLists.Where(s => s.publicID == publicId).FirstOrDefault();
            sl.dateUpdate = System.DateTime.Now;
            context.SaveChanges();
        }
    }


}
