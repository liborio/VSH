using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EV
{
    public class EVEveApi
    {
        public int KeyId { get; set; }
        public string VerificationCode { get; set; }
        public IList<EVEveCharacter> Characters { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateUpdate { get; set; }

        public EVEveApi()
        {
            Characters = new List<EVEveCharacter>();
        }
    }
}
