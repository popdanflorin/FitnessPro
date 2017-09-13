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

        public List<Workout> GetWorkouts()
        {
            return ctx.Workouts.ToList();
        }
        public List<WorkoutInstance> GetWorkoutInstances() {
            return ctx.WorkoutInstances.Include("Workout").ToList();
        }

        public List<WorkoutExercise> GetWorkoutExercises() {
            return ctx.WorkoutExercises.ToList();
        }

        public List<EnumItem> GetWorkoutStatuses()
        {
            return Enum.GetValues(typeof(StatusType)).Cast<StatusType>().Select(x => new EnumItem() { Id = (int)x, Description = x.ToString() }).ToList();
        }
    }
}