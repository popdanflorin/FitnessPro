using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessPro.Controllers
{
    public class WorkoutInstanceController : Controller
    {
        // GET: WorkoutInstance
        public ActionResult List()
        {
            return View();
        }
    }
}