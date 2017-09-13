using System.Web.Mvc;
using FitnessPro.Entities;
using FitnessPro.Services;
using System.Text;

namespace FitnessPro.Controllers
{
    public class WorkoutInstanceController : Controller
    {
        private WorkoutInstanceQueryService qService = new WorkoutInstanceQueryService();
        private WorkoutInstanceCommandService cService = new WorkoutInstanceCommandService();
        private WorkoutQueryService WqService = new WorkoutQueryService();
        // GET: WorkoutInstance
        public ActionResult List()
        {
            return View();
        }

        public JsonResult ListRefresh()
        {
            var workouts = WqService.GetWorkouts();
            var workoutInstanes = qService.GetWorkoutInstances();
            var workoutExercises = qService.GetWorkoutExercises();
            return new JsonResult() { Data = new { Workouts = workouts, WorkoutInstances=workoutInstanes, WorkoutExercises=workoutExercises }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult Save(WorkoutInstance workoutInstance)
       {
            var message = cService.SaveWorkoutInstance(workoutInstance);
            return new JsonResult() { Data = message, ContentEncoding = Encoding.UTF8 };
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var message = cService.DeleteWorkoutInstance(id);
            return new JsonResult() { Data = message, ContentEncoding = Encoding.UTF8 };
        }
    }
}