using EveShopping.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Repositorios
{
    public class RepositorioBase
    {
        protected EveShoppingContext Contexto { get; set; }


        public RepositorioBase() : this(new EveShoppingContext())
        {
            
        }

        public RepositorioBase(EveShoppingContext _contexto)
        {
            Contexto = _contexto;
        }

    }
}
