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
            var CompletedWorkoutInstances = qService.GetCompletedWorkoutInstances(User.Identity.Name);
            var TotalPercentage = qService.GetTotalPercentage(CompletedWorkoutInstances);
            var TotalPoints = qService.GetTotalPoints(CompletedWorkoutInstances);
            var UserName = User.Identity.Name;
            return new JsonResult() { Data = new { CompletedWorkoutInstances = CompletedWorkoutInstances , TotalPercentage = TotalPercentage, TotalPoints = TotalPoints, UserName = UserName }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult DatePercentageListRefresh()
        {
            var datePercentageList = qService.GetCompletedWorkoutInstances_DatePercentageList(User.Identity.Name);
            var workoutPercentageList = qService.GetCompletedWorkoutInstances_WorkoutPercentageList(User.Identity.Name);

            return new JsonResult() { Data = new { datePercentageList = datePercentageList, workoutPercentageList = workoutPercentageList }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        
    }
}