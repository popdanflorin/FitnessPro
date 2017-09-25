using FitnessPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FitnessPro.Controllers
{
    public class LogsController : Controller
    {
        private LogQueryService qService = new LogQueryService();
        // GET: Log
        public ActionResult Logs()
        {
            return View();
        }
        public JsonResult ListRefresh()
        {
            var Logs = qService.GetLogs(User.Identity.Name);
            return new JsonResult() { Data = new { Logs = Logs }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}