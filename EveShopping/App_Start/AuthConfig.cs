using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using EveShopping.Models;

namespace EveShopping

{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "Ao1rpYXjeTauCGwDEpg5w",
                consumerSecret: "ieMyxQWLap4XqJEaCeEpvR2xp1Qcg021NuJ44Forv0M");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "343050129164564",
                appSecret: "6576a6253624845a4b40de37e63f9362");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
