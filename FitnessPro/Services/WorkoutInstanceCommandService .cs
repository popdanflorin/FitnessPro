using FitnessPro.Entities;
using FitnessPro.Models;
using System;
using System.Linq;

namespace FitnessPro.Services
{
    public class WorkoutInstanceCommandService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        private const string SuccessMessage = "Action sucessfully performed.";
        private const string ErrorMessage = "An application exception occured performing action.";
        private const string ItemNotFoundMessage = "The item was not found.";
        public string SaveWorkoutInstance(WorkoutInstance workoutInstance)
        {
            try
            {
                var oldWorkoutInstance = ctx.WorkoutInstances.FirstOrDefault(f => f.Id == workoutInstance.Id);
                if (oldWorkoutInstance == null)
                {
                    workoutInstance.Id = Guid.NewGuid().ToString();
                    ctx.WorkoutInstances.Add(workoutInstance);
                }
                else
                {
                    oldWorkoutInstance.WorkoutId = workoutInstance.WorkoutId;
                    oldWorkoutInstance.Date = workoutInstance.Date;
                    oldWorkoutInstance.Status = workoutInstance.Status;
                    oldWorkoutInstance.UserId = workoutInstance.UserId;
                }

                ctx.SaveChanges();
                return SuccessMessage;
            }
            catch
            {
                return ErrorMessage;
            }
        }

        public string DeleteWorkoutInstance(string id)
        {
            try
            {
                var workoutInstance = ctx.WorkoutInstances.FirstOrDefault(f => f.Id == id);
                if (workoutInstance != null)
                {
                    ctx.WorkoutInstances.Remove(workoutInstance);
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