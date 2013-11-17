using EveAI.Live;
using EveAI.Live.Account;
using EveShopping.Comun.Infraestructure;
using EveShopping.Modelo;
using EveShopping.Modelo.EV;
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
        public EVEveApi GetAPIInformation(int keyId, string vCode)
        {
            EVEveApi vapi = new EVEveApi();

            EveApi api = new EveApi(keyId, vCode);

            APIKeyInfo keyInfo = api.getApiKeyInfo();

            vapi.KeyId = keyId;
            vapi.VerificationCode = vCode;
            vapi.IsActive = false;
            
            if( keyInfo.Characters == null || keyInfo.Characters.Count == 0){
                throw new ApplicationException(Translator.T("The API information for the account doesn't exist or it is expired"));
            }

            foreach (var character in keyInfo.Characters)
            {
                EVEveCharacter vchar = new EVEveCharacter();
                vchar.Name = character.Name;
                vchar.EveId = character.CharacterID;
                vchar.CorpName = character.CorporationName;
                vchar.CorpId = character.CorporationID;
                vchar.CorpTicker = GetCorpTicker(keyId, vCode, character.CorporationID.ToString());
                vapi.Characters.Add(vchar);
            }

            return vapi;

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
