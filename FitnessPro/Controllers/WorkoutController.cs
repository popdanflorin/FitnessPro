using FitnessPro.Entities;
using FitnessPro.Services;
using System.Text;
using System.Web.Mvc;

namespace FitnessPro.Controllers
{
    public class WorkoutController : Controller
    {
        private WorkoutQueryService qService = new WorkoutQueryService();
        private WorkoutCommandService cService = new WorkoutCommandService();

        // GET: Workout
        public ActionResult List()
        {
            return View();
        }

        public JsonResult ListRefresh()
        {
            var workouts = qService.GetWorkouts();
            var workoutTypes = qService.GetWorkoutTypes();
            return new JsonResult() { Data = new { Workouts = workouts, WorkoutTypes = workoutTypes }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult Save(Workout workout)
        {
            var message = cService.SaveWorkout(workout);
            return new JsonResult() { Data = message, ContentEncoding = Encoding.UTF8 };
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var message = cService.DeleteWorkout(id);
            return new JsonResult() { Data = message, ContentEncoding = Encoding.UTF8 };
        }

        [HttpPost]
        public JsonResult GetEx(string workoutId)
        {
            var exercises = qService.GetExercises(workoutId);
            return new JsonResult() { Data = new { Exercises = exercises }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}