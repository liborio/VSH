using EveShopping.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Loggin
{
    public class VSHLoggin
    {
        public static void Log(eLogSeverity severity, int code, string msg){
            EveShoppingContext contexto = new EveShoppingContext();
            
            eshLog log = new eshLog();
            log.Severity = (short)severity;
            log.Code = code;
            log.Message = msg;
            log.Date = System.DateTime.Now;

            if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                string userName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                UserProfile usu = contexto.userProfiles.Where(u => u.UserName == userName).FirstOrDefault();
                if (usu != null)
                {
                    log.UserID = usu.UserId;
                }
            }

            contexto.eshLogs.Add(log);
            contexto.SaveChanges();
        }
    }
}
