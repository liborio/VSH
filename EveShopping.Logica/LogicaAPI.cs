using EveAI.Live;
using EveAI.Live.Account;
using EveShopping.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveShopping.Logica
{
    public class LogicaAPI
    {
        public EveApi GetAPIInformation(int keyId, string vCode)
        {
            eshEveAccount eveAccount = new eshEveAccount();

            EveApi api = new EveApi(keyId, vCode);

            APIKeyInfo keyInfo = api.getApiKeyInfo();

            eveAccount.keyID = keyId;
            eveAccount.verficationCode = vCode;
            eveAccount.isActive = false;
            

            foreach (var character in keyInfo.Characters)
            {
                string ticker = GetCorpTicker(keyId, vCode, character.CorporationID.ToString());
            }

            return api;

        }

        private string GetCorpTicker(long keyId, string vCode, string corpId)
        {
            string url = string.Format("https://api.eveonline.com/corp/CorporationSheet.xml.aspx?keyID={0}&Vcode={1}&corporationID={2}", keyId, vCode, corpId);
            System.Net.WebRequest request = System.Net.HttpWebRequest.Create(url);
            WebResponse respuesta = request.GetResponse();
            XDocument doc = null;
            using (Stream canalRespuesta = respuesta.GetResponseStream())
            {
                doc = XDocument.Load(canalRespuesta);
            }
            //obtenemos el corp ticker
            if (doc == null)
            {
                throw new ApplicationException("The eve api response is not xml");
            }
            XElement eticker = doc.Descendants().Where(d => d.Name == "ticker").FirstOrDefault();
            if (eticker == null)
            {
                throw new ApplicationException("Ticker not received frome eve api");
            }
            return eticker.Value;

        }
    }
}
