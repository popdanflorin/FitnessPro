using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessPro.Controllers
{
    public class WorkoutController : Controller
    {
        // GET: Workout
        public ActionResult List()
        {
            return View();
        }
    }
}