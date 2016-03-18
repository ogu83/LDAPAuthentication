using System;
using System.Security.Principal;
using System.Web;

namespace WcfService
{
    public class HttpAuthenticationModule : IHttpModule
    {
        public void Dispose()
        { }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += context_AuthenticateRequest;
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext.Current.User = ProcessAuthentication();
        }

        private static IPrincipal ProcessAuthentication()
        {
            //TODO: implement authentication here
            IIdentity identity = new GenericIdentity("Authenticated User");
            return new GenericPrincipal(identity, null);
        }
    }
}
