using EveAI.Live;
using EveShopping.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web
{
    public class AgenteAPI
    {
        public EveApi SaveAPIInformation(long keyId, string vCode)
        {
            LogicaAPI lociga = new LogicaAPI();
            return lociga.GetAPIInformation(keyId, vCode);
        }
    }
}
