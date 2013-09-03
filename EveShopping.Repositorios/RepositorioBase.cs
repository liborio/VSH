using EveShopping.Modelo;
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
            if (_contexto == null)
            {
                _contexto = new EveShoppingContext();   
            }
            Contexto = _contexto;
        }

    }
}
