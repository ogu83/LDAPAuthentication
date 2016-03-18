using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfService
{
    public static class LogHelper
    {
        public static void AddLog(string username, string domain, bool success, string message, DateTime requestDate)
        {
            using (var entities = new db_ArchitectNetLDAPEntities())
            {
                entities.LoginLog.Add(new LoginLog
                {
                    Username = username,
                    Domain = domain,
                    RequestDate = requestDate,
                    ResponseDate = DateTime.Now,
                    ResponseMessage = message,
                    Success = success ? 1 : 0
                });
                try
                {
                    entities.SaveChanges();
                }
                catch (Exception)
                {

                }
            }
        }

        public static List<LoginLog> GetLogs()
        {
            using (var entities = new db_ArchitectNetLDAPEntities())
            {
                var retval = entities.LoginLog.Where(x => x.Success != 0).OrderBy(y => y.ResponseDate);
                return retval.ToList();
            }
        }
    }
}