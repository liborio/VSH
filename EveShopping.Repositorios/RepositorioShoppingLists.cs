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
        public RepositorioShoppingLists(EveShoppingContext contexto = null)
            : base(contexto)
        {
        }

        public void CrearShoppingList(eshShoppingList lista)
        {
            this.Contexto.eshShoppingLists.Add(lista);
            this.Contexto.SaveChanges();
        }
    }
}
