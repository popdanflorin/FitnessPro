using FitnessPro.Entities;
using FitnessPro.Entities.Enums;
using FitnessPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessPro.Services
{
    public class WorkoutQueryService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        public List<Workout> GetWorkouts()   
        {
            var workouts = ctx.Workouts.ToList();
            //active
            return workouts;
        }
        public List<WorkoutExercise> GetExercises(string workoutid)
        {
            return ctx.WorkoutExercises.Where(x => x.WorkoutId == workoutid).ToList(); 
            //active
        }
        public List<EnumItem> GetWorkoutTypes()
        {
            return Enum.GetValues(typeof(WorkoutType)).Cast<WorkoutType>().Select(x => new EnumItem() { Id = (int)x, Description = x.ToString() }).ToList();
        }
    }
}