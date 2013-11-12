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
        public RepositorioItems(EveShoppingContext contexto = null)
            : base(contexto)
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

        public IList<invMarketGroup> GetParentGroupsChainStartingTop(int idGroup, int topGroupId)
        {
            Stack<invMarketGroup> pilaGroups = new Stack<invMarketGroup>();
            IList<invMarketGroup> listaSalida = new List<invMarketGroup>();

            invMarketGroup group = Contexto.invMarketGroups.Where(g => g.marketGroupID == idGroup).FirstOrDefault();

            if (group == null)
            {
                return listaSalida;
            }

            pilaGroups.Push(group);

            while (group.parentGroupID.HasValue && group.parentGroupID != topGroupId)
            {
                group = Contexto.invMarketGroups.Where(g => g.marketGroupID == group.parentGroupID.Value).FirstOrDefault();

                if (group.marketGroupID != topGroupId)
                {
                    pilaGroups.Push(group);
                }
            }

            while (pilaGroups.Count > 0)
            {
                listaSalida.Add(pilaGroups.Pop());
            }
            return listaSalida;
        }

        public IEnumerable<invMarketGroup> SelectMarketGroupsByParentID(int? parentID)
        {
            return Contexto.invMarketGroups.Where(g => parentID.HasValue ? g.parentGroupID == parentID : !g.parentGroupID.HasValue)
                .OrderBy(g => g.marketGroupName).ToList();
        }

        public static double GetVolume(invType it)
        {
            switch (it.groupID)
            {
                //Assault frigate
                case 324:
                    return 2500;
                //Attack battlecruiser
                case 1201:
                    return 15000;
                //Battleship
                case 27:
                    return 50000;
                //Black Ops
                case 898:
                    return 50000;
                //Blockade Runner
                case 1202:
                    return 20000;
                //Capital Industrial Ship
                case 883:
                    return 1000000;
                //Capsule
                case 29:
                    return 1;
                //Carrier
                case 547:
                    return 1000000;
                //Combat Battlecruiser
                case 419:
                    return 15000;
                //Combat Recon Ship
                case 906:
                    return 10000;
                //Command Ship
                case 540:
                    return 15000;
                //Covert Ops
                case 830:
                    return 2500;
                //Cruiser
                case 26:
                    return 10000;
                //Deep Space Transport
                case 380:
                    return 20000;
                //Destroyer
                case 420:
                    return 5000;
                //Dreadnought
                case 485:
                    return 1000000;
                //Electronic Attack Ship
                case 893:
                    return 2500;
                //Elite Battleship
                case 381:
                    return 50000;
                //Exhumer
                case 543:
                    return 3750;
                //Force Ship
                case 833:
                    return 1000;
                //Freighter
                case 513:
                    return 1000000;
                //Frigate
                case 25:
                    return 2500;
                //Heavy Assault Cruiser
                case 358:
                    return 10000;
                //Heavy Interdiction Cruiser
                case 894:
                    return 10000;
                //Industrial
                case 28:
                    return 20000;
                //Industrial Command Ship
                case 941:
                    return 500000;
                //Interceptor
                case 831:
                    return 2500;
                //Interdictor
                case 541:
                    return 5000;
                //Jump Freighter
                case 902:
                    return 1000000;
                //Logistics
                case 832:
                    return 10000;
                //Marauder
                case 900:
                    return 50000;
                //Mining Barge
                case 463:
                    return 3750;
                //Prototype Exploration Ship
                case 1022:
                    return 500;
                //Rookie ship
                case 237:
                    return 2500;
                //Shuttle
                case 31:
                    return 500;
                //Stealth Bomber
                case 834:
                    return 2500;
                //Strategic Cruiser
                case 963:
                    return 5000;
                //Supercarrier
                case 659:
                    return 1000000;
                //Titan
                case 30:
                    return 10000000;
                default:
                    return it.volume.Value;
            }
        }

        public double GetVolume(int invTypeID)
        {
            return GetVolume(Contexto.invTypes.Where(i => i.typeID == invTypeID).First());
        }

    }
}
