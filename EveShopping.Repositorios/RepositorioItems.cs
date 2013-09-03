using EveShopping.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Repositorios
{
    public class RepositorioItems : RepositorioBase
    {
        public RepositorioItems(EveShoppingContext contexto = null) : base(contexto)
        { }


        public invType SelectItemTypePorName(string name)
        {
            return Contexto.invTypes.Where(t => t.typeName.Equals(name)).FirstOrDefault();
        }
    }
}
