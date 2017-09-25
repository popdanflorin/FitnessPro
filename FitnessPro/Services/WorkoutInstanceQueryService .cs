using FitnessPro.Entities;
using FitnessPro.Entities.Enums;
using FitnessPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessPro.Services
{
    public class WorkoutInstanceQueryService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        private WorkoutQueryService qService = new WorkoutQueryService();

        public List<Workout> GetWorkouts()
        {
            return ctx.Workouts.Where(wie => wie.Active == true).ToList();
        }
        public List<WorkoutExercise> GetExercises()
        {
            return ctx.WorkoutExercises.Where(wie => wie.ActiveEx == true).ToList(); 
        }
        public List<WorkoutInstance> GetWorkoutInstances(string UserName) {
            return ctx.WorkoutInstances.Include("Workout").Where(wie => wie.Active == true && wie.UserId == UserName ).ToList();
        }
        public List<WorkoutInstance> GetCompletedWorkoutInstances(string UserName) {
            return ctx.WorkoutInstances.Include("Workout").Where(wie => wie.Status == Entities.Enums.StatusType.Completed && wie.UserId == UserName).ToList();
        }
        public List<WorkoutInstanceExercise> GetWorkoutInstanceExercises(string workoutInstanceId) {
            var exercises = ctx.WorkoutExercises.ToList();
            var wiex = ctx.WorkoutInstanceExercises.Where(wix => (wix.WorkoutInstanceId == workoutInstanceId) &&( wix.Active == true)).ToList();
            foreach (var item in wiex)
            {
                item.ExerciseName = exercises.FirstOrDefault(e => e.Id == item.ExerciseId).Name;
            }
            return wiex;
        }
        public List<WorkoutInstanceExercise> GetWorkoutExercisesForCreation(string workoutId)
        {
            var exercises = qService.GetExercises(workoutId);
            var result = new List<WorkoutInstanceExercise>();
            foreach (var ex in exercises)
            {
                var wie = new WorkoutInstanceExercise();
                wie.Id = Guid.NewGuid().ToString();
                wie.ExerciseId = ex.Id;
                wie.ExerciseName = ex.Name;
                wie.PlannedRepetitions = ex.Repetitions;
                wie.Active = true;
                result.Add(wie);
            }
            return result;
        }
        public List<EnumItem> GetWorkoutStatuses()
        {
            return Enum.GetValues(typeof(StatusType)).Cast<StatusType>().Select(x => new EnumItem() { Id = (int)x, Description = x.ToString() }).ToList();
        }
        public List<Log> GetLogs(string UserName) {
            return ctx.Logs.Where(wie => wie.UserId == UserName).ToList();
        }
    }
}