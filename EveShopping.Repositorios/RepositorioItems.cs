using EveShopping.Modelo.Models;
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

        public IEnumerable<invType> SelectInvTypeByGroupID(int? parentID)
        {
            return Contexto.invTypes.Where(g => g.marketGroupID == parentID)
                .OrderBy(g => g.typeName).ToList();
        }

        public IList<invMarketGroup> GetParentGroupsChainStartingTop(int idGroup)
        {
            Stack<invMarketGroup> pilaGroups = new Stack<invMarketGroup>();
            IList<invMarketGroup> listaSalida = new List<invMarketGroup>();

            invMarketGroup group = Contexto.invMarketGroups.Where(g => g.marketGroupID == idGroup).FirstOrDefault();

            if (group == null)
            {
                return listaSalida;
            }

            pilaGroups.Push(group);

            while (group.parentGroupID.HasValue)
            {
                group = Contexto.invMarketGroups.Where(g => g.marketGroupID == group.parentGroupID.Value).FirstOrDefault();
                pilaGroups.Push(group);
            }
            
            while (pilaGroups.Count > 0)
            {
                listaSalida.Add(pilaGroups.Pop());
            }
            return listaSalida;
        }

        public IEnumerable<invMarketGroup> SelectMarketGroupsByParentID(int? parentID)
        {
            return Contexto.invMarketGroups.Where(g => parentID.HasValue? g.parentGroupID == parentID: ! g.parentGroupID.HasValue)
                .OrderBy(g => g.marketGroupName).ToList();
        }

        public double GetVolume(invType it)
        {
            return it.volume.Value;
        }

        public double GetVolume(int invTypeID)
        {
            return GetVolume(Contexto.invTypes.Where(i => i.typeID == invTypeID).First());
        }

    }
}
