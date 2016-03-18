using ArchitectNetLDAP.LDAPServiceReference;
using ArchitectNetLDAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectNetLDAP.Controllers
{
    public class LogController : Controller
    {
        //
        // GET: /Log/
        public ActionResult Index()
        {
            LogModel model = new LogModel();
            using (var client = new LDAPLoginServiceClient())
            {
                var logs = client.GetLogs();
                model.Logs = logs.Logs.Select(x => new LogEntry { Username = x.Username, LoginDate = x.LoginDate }).ToList();
            }
            return View(model);
        }
    }
}