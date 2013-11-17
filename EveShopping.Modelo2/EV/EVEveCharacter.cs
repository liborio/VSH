using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EV
{
    public class EVEveCharacter
    {
        public int Id { get; set; }
        public long EveId { get; set; }
        public string Name { get; set; }
        public long CorpId { get; set; }
        public string CorpName { get; set; }
        public string CorpTicker { get; set; }
        public long AlliId { get; set; }
        public string AlliName { get; set; }
        public string AlliTicker { get; set; }
        public string ImageUrl { get; set; }
    }
}
