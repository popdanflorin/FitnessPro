using System.Web.Mvc;
using FitnessPro.Entities;
using FitnessPro.Services;
using System.Text;

namespace FitnessPro.Controllers
{
    public class ResultsController : Controller
    {
        private WorkoutInstanceQueryService qService = new WorkoutInstanceQueryService();
        private WorkoutInstanceCommandService cService = new WorkoutInstanceCommandService();
        // GET: Results
        public ActionResult Results()
        {
            return View();
        }
        public JsonResult ListRefresh()
        {
            var CompletedWorkoutInstances = qService.GetCompletedWorkoutInstances();
            return new JsonResult() { Data = new { CompletedWorkoutInstances = CompletedWorkoutInstances }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}