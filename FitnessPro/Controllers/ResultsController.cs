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
            var TotalPercentage = cService.GetTotalPercentage(CompletedWorkoutInstances);
            var TotalPoints = cService.GetTotalPoints(CompletedWorkoutInstances);
            
            return new JsonResult() { Data = new { CompletedWorkoutInstances = CompletedWorkoutInstances , TotalPercentage = TotalPercentage, TotalPoints = TotalPoints, UserName = User.Identity.Name }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}