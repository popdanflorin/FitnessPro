using FitnessPro.Entities;
using FitnessPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessPro.Services
{
    public class WorkoutInstanceCommandService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        private const string SuccessMessage = "Action sucessfully performed.";
        private const string ErrorMessage = "An application exception occured performing action.";
        private const string ItemNotFoundMessage = "The item was not found.";
        public string SaveWorkoutInstanceWithExercises(WorkoutInstance workoutInstance, List<WorkoutInstanceExercise> workoutInstanceExercises)
        {
            try
            {
                var oldWorkoutInstance = ctx.WorkoutInstances.FirstOrDefault(f => f.Id == workoutInstance.Id);
                if (oldWorkoutInstance == null)
                {
                    workoutInstance.Id = Guid.NewGuid().ToString();
                    workoutInstance.Active = true;
                    ctx.WorkoutInstances.Add(workoutInstance);
                }
                else
                {
                    oldWorkoutInstance.WorkoutId = workoutInstance.WorkoutId;
                    if (workoutInstance.Status == Entities.Enums.StatusType.Planned) {
                        if (workoutInstance.Date != DateTime.MinValue)
                        {
                            oldWorkoutInstance.Date = workoutInstance.Date;
                        }
                    };
                    oldWorkoutInstance.Status = workoutInstance.Status;
                    oldWorkoutInstance.UserId = workoutInstance.UserId;
                    oldWorkoutInstance.Active = workoutInstance.Active;
                    oldWorkoutInstance.Rounds = workoutInstance.Rounds;
                    
                }
                
                var TotalSum = 0.0;
                var numberOfExercises = 0;
                foreach (var wIE in workoutInstanceExercises)
                {
                    var oldWorkoutInstanceExercise = ctx.WorkoutInstanceExercises.FirstOrDefault(f => f.Id == wIE.Id);
                    if (oldWorkoutInstanceExercise == null)
                    {
                        wIE.Id = Guid.NewGuid().ToString();
                        wIE.WorkoutInstanceId = workoutInstance.Id;
                        ctx.WorkoutInstanceExercises.Add(wIE);
                    }
                    else
                    {
                        oldWorkoutInstanceExercise.PlannedRepetitions = wIE.PlannedRepetitions;
                        oldWorkoutInstanceExercise.ActualRepetitions = wIE.ActualRepetitions;
                        if (oldWorkoutInstance.Status.Equals("Completed"))
                        {
                            numberOfExercises++;
                            TotalSum =TotalSum + ((oldWorkoutInstanceExercise.ActualRepetitions * 100) / oldWorkoutInstanceExercise.PlannedRepetitions);
                    }
                    }
                }
                if (oldWorkoutInstance.Status.Equals("Completed"))
                {
                    oldWorkoutInstance.Percentage = TotalSum / numberOfExercises;
                    if (oldWorkoutInstance.Percentage < 100.00)
                        oldWorkoutInstance.Points = oldWorkoutInstance.Percentage / 10;
                    else
                    {
                        if (oldWorkoutInstance.Percentage < 150.00) oldWorkoutInstance.Points = 15;   //10+5
                        else
                          if (oldWorkoutInstance.Percentage < 200.00) oldWorkoutInstance.Points = 20; //10+10
                        else oldWorkoutInstance.Points = 30; //10+20
                    }

                }





                 ctx.SaveChanges();
                return SuccessMessage;
            }
            catch (Exception ex)
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
                    var wIExercises = ctx.WorkoutInstanceExercises.Where(wie => wie.WorkoutInstanceId == workoutInstance.Id);
                    foreach (var wIE in wIExercises) {
                        wIE.Active = false;
                    };
                    workoutInstance.Active = false;
                    //ctx.WorkoutInstanceExercises.RemoveRange(wIExercises);
                    //ctx.WorkoutInstances.Remove(workoutInstance);
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