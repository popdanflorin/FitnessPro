using FitnessPro.Entities;
using FitnessPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessPro.Services
{
    public class WorkoutCommandService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        private const string SuccessMessage = "Action sucessfully performed.";
        private const string ErrorMessage = "An application exception occured performing action.";
        private const string ItemNotFoundMessage = "The item was not found.";
        public string SaveWorkout(Workout workout)
        {
            try
            {
                var oldWorkout = ctx.Workouts.FirstOrDefault(f => f.Id == workout.Id);
                if (oldWorkout == null)
                {
                    workout.Id = Guid.NewGuid().ToString();
                    ctx.Workouts.Add(workout);
                }
                else
                {
                    oldWorkout.Name = workout.Name;
                    oldWorkout.Description = workout.Description;
                    oldWorkout.Type = workout.Type;
                }

                ctx.SaveChanges();
                return SuccessMessage;
            }
            catch
            {
                return ErrorMessage;
            }
        }

        public string DeleteWorkout(string id)
        {
            try
            {
                var workout = ctx.Workouts.FirstOrDefault(f => f.Id == id);
                if (workout != null)
                {
                    ctx.Workouts.Remove(workout);
                    ctx.SaveChanges();
                    return SuccessMessage;
                }
                return ItemNotFoundMessage;
            }
            catch (Exception)
            {
                return ErrorMessage;
            }
        }
    }
}