using FormsAuth;
using System;
using System.ServiceModel.Activation;
using System.Web.Configuration;
using System.Linq;

namespace WcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LDAPLoginService : ILDAPLoginService
    {
        private string ldapPath { get { return WebConfigurationManager.AppSettings["LdapPath"]; } }

        public LoginResponse Login(LoginRequest request)
        {
            var retval = new LoginResponse();
            DateTime requesTime = DateTime.Now;
            try
            {
                var auth = new LdapAuthentication(ldapPath);
                retval.IsOK = auth.IsAuthenticated(request.Domain, request.Username, request.Password);
                retval.Message = "Login Success";
            }
            catch (Exception ex)
            {
                retval.IsOK = false;
                retval.Message = ex.Message;
            }
            finally
            {
                LogHelper.AddLog(request.Username, request.Domain, retval.IsOK, retval.Message, requesTime);
            }
            return retval;
        }

        public LoginLogs GetLogs()
        {
            var logs = LogHelper.GetLogs();
            var retval = new LoginLogs();
            retval.Logs = logs.Select(x => new LoginLogElement { Username = x.Username, LoginDate = x.ResponseDate }).ToList();
            return retval;
        }
    }
}