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
            return ctx.Workouts.ToList();
        }
        //get workoutexercises
        public List<WorkoutExercise> GetExercises()
        {
            return ctx.WorkoutExercises.ToList();
        }

        //
        public List<WorkoutInstance> GetWorkoutInstances() {
            return ctx.WorkoutInstances.Include("Workout").ToList();
        }

        public List<WorkoutInstanceExercise> GetWorkoutInstanceExercises(string workoutInstanceId) {
            var exercises = ctx.WorkoutExercises.ToList();
            var wiex = ctx.WorkoutInstanceExercises.Where(wix => wix.WorkoutInstanceId == workoutInstanceId).ToList();
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
                result.Add(wie);
            }
            return result;
        }

        public List<EnumItem> GetWorkoutStatuses()
        {
            return Enum.GetValues(typeof(StatusType)).Cast<StatusType>().Select(x => new EnumItem() { Id = (int)x, Description = x.ToString() }).ToList();
        }
    }
}