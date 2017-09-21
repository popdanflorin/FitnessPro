using System.Web.Mvc;
using FitnessPro.Entities;
using FitnessPro.Services;
using System.Text;
using System.Collections.Generic;

namespace FitnessPro.Controllers
{
    public class WorkoutInstanceController : Controller
    {
        private WorkoutInstanceQueryService qService = new WorkoutInstanceQueryService();
        private WorkoutInstanceCommandService cService = new WorkoutInstanceCommandService();
        private WorkoutQueryService WqService = new WorkoutQueryService();
        private WorkoutCommandService WcService = new WorkoutCommandService();
        // GET: WorkoutInstance
        public ActionResult List()
        {
            return View();
        }

        public JsonResult ListRefresh()
        {
            var workouts = WqService.GetWorkouts();
            var workoutInstanes = qService.GetWorkoutInstances(User.Identity.Name);
            return new JsonResult() { Data = new { Workouts = workouts, WorkoutInstances = workoutInstanes }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult RefreshExercises(string workoutId)
        {
            var instanceExercises = qService.GetWorkoutExercisesForCreation(workoutId);
            return new JsonResult() { Data = new { Exercises = instanceExercises }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult RefreshExercisesForDetails(string workoutInstanceId)
        {
            var instanceExercises = qService.GetWorkoutInstanceExercises(workoutInstanceId);
            return new JsonResult() { Data = new { Exercises = instanceExercises }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveInstanceWithExercises(WorkoutInstance workoutInstance, List<WorkoutInstanceExercise> vIExercises)
        {
            //, User.Identity.Name
            var message = cService.SaveWorkoutInstanceWithExercises(workoutInstance, vIExercises , User.Identity.Name);
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