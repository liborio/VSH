using EveShopping.Logica.Conversion;
using EveShopping.Modelo;
using EveShopping.Modelo.Models;
using EveShopping.Modelo.EntidadesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using EveShopping.Repositorios;

namespace EveShopping.Logica
{
    public class LogicaShoppingLists
    {
        public IEnumerable<FittingAnalyzed> ObtenerListaFits(string fitOriginal, Enumerados.TipoFormatoFitOriginal tipo){
            IConversorFit conv = null;
            switch (tipo)
            {
                case Enumerados.TipoFormatoFitOriginal.EFT:
                    throw new NotImplementedException();
                    break;
                case Enumerados.TipoFormatoFitOriginal.EveXml:
                default:
                    conv = new ConversorEveXmlToFitList();
                    break;
            }
            return conv.ToFitList(fitOriginal);
        }

        public string CrearShoppingList(eshShoppingList lista)
        {
            string publicID = Guid.NewGuid().ToString();
            lista.publicID = publicID;
            EveShoppingContext contexto = new EveShoppingContext();
            contexto.eshShoppingLists.Add(lista);
            contexto.SaveChanges();
            return publicID;
        }

        public int SaveAnalisedFit(string listPublicId, FittingAnalyzed fitAnalysed, int? userId = null)
        {
            eshShoppingList lista = null;
            using (TransactionScope scope = new TransactionScope())
            {
                RepositorioShoppingLists repo = new RepositorioShoppingLists();
                lista = repo.SelectShopingListPorPublicID(listPublicId);

                if (lista == null)
                {
                    lista = new eshShoppingList();
                    lista.publicID = listPublicId;
                    repo.CrearShoppingList(lista);
                }
                eshFitting fit = MountFittingFromFittingAnalysed(fitAnalysed);
                eshShoppingListFitting relation = new eshShoppingListFitting();
                fit.eshShoppingListFittings.Add(relation);
                relation.eshShoppingList = lista;
                relation.units = 1;

                repo.CrearFitting(fit);

                scope.Complete();
            }
            return lista.shoppingListID;
        }

        public eshFitting MountFittingFromFittingAnalysed(FittingAnalyzed fit)
        {
            RepositorioItems repo = new RepositorioItems();
            eshFitting salida = new eshFitting();
            salida.name = fit.Name;
            salida.description = fit.Description;
            invType shipType = repo.SelectItemTypePorName(fit.Ship);
            if (shipType == null)
            {
                throw new ApplicationException(Messages.err_nombreItemAnalizadaNoExiste);
            }
            salida.shipTypeID = shipType.typeID;
            salida.shipVolume = shipType.volume.Value;

            double totalVol = salida.shipVolume;
            foreach (var item in fit.Items)
            {
                eshFittingHardware fhwd = MountFittingHardware(item, repo);
                salida.eshFittingHardwares.Add(fhwd);
                totalVol += fhwd.volume;
            }
            salida.volume = totalVol;
            

            return salida;
        }

        public eshFittingHardware MountFittingHardware(FittingHardwareAnalyzed fithwd, RepositorioItems repo)
        {
            invType tipo = repo.SelectItemTypePorName(fithwd.Name);
            if (tipo == null)
            {
                throw new ApplicationException(Messages.err_nombreItemAnalizadaNoExiste);
            }
            eshFittingHardware salida = new eshFittingHardware();
            salida.positionInSlot = 0;
            salida.slotID = fithwd.Slot;
            salida.units = fithwd.Units;
            salida.volume = tipo.volume.Value * fithwd.Units;
            
            return salida;
        }


    }
}
