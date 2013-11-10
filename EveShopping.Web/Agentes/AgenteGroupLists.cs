using EveShopping.Logica;
using EveShopping.Modelo.EV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Agentes
{
    public class AgenteGroupLists
    {
        public string CreateGroupList(string userName, string name, string description)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.CreateGroupList(userName, name, description);
        }

        public bool IsGroupListOwner(string publicID, string userName = null)
        {
            

            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.IsListOwner(publicID, userName);
        }

        public void RemoveListFromGroup(string groupPublicID, string listPublicID, string userName)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            logica.RemoveListFromGroup(groupPublicID, listPublicID, userName);
        }

        public void DeleteList(string userName, string publicID)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            logica.DeleteGroupList(userName, publicID);
        }
        
        private string GetStaticPublicIDFromURL(string staticUrl){
                        if (string.IsNullOrEmpty(staticUrl)){       
                throw new ApplicationException(Messages.err_providedUrlNotValid);
            }
            int pos = staticUrl.LastIndexOf("/");
            string strguid = null;
            if (staticUrl.Length == pos + 1)
            {
                throw new ApplicationException(Messages.err_providedUrlNotValid);
            }
            if (pos <= 0)
            {
                strguid = staticUrl;
            }
            else{
                strguid = staticUrl.Substring(pos + 1);
            }
            return strguid;
        }

        public string IncludeStaticListInGroup(string staticUrl, string publicID, string userName, string nick)
        {
            string strguid = GetStaticPublicIDFromURL(staticUrl);
            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.AddListToGroup(publicID, strguid, userName, nick, new Imagex32UrlResolver());
        }

        public void ActualizarGroupListHeader(string publicID, string userName, string name, string description)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            logica.ActualizarGroupListHeader(publicID, userName, name, description);
        }

        public bool IsListOwner(string publicID, string userName)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.IsListOwner(publicID, userName);
        }

        public IEnumerable<EVStaticList> SelectStaticListsHeadersByGroupId(string groupID)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.SelectStaticListsHeadersByGroupId(groupID);
        }

        public EVStaticList SelectStaticListHeaderById(string groupID, string staticUrl)
        {
            string strguid = staticUrl; //GetStaticPublicIDFromURL(staticUrl);
            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.SelectStaticListHeaderById(groupID, strguid);
        }

        public IList<EVShoppingListHeader> SelectGroupListsByUserName(string userName)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.SelectGroupListsByUserName(userName);
        }

        public EVListSummary SelectGroupListSummaryPorPublicID(string publicID)
        {
            LogicaGroupLists logica = new LogicaGroupLists();
            return logica.SelectGroupListSummaryPorPublicID(publicID, new Imagex32UrlResolver());
        }

    }
}
