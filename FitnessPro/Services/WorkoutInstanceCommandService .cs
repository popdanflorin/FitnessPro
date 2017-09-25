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
        private ApplicationUser usr = new ApplicationUser();
        private const string SuccessMessage = "Action sucessfully performed.";
        private const string ErrorMessage = "An application exception occured performing action.";
        private const string ItemNotFoundMessage = "The item was not found.";
        public string SaveWorkoutInstanceWithExercises(WorkoutInstance workoutInstance, List<WorkoutInstanceExercise> workoutInstanceExercises , string UserName) //, string userName
        {
            try
            {
                var oldWorkoutInstance = ctx.WorkoutInstances.FirstOrDefault(f => f.Id == workoutInstance.Id);
                

                if (oldWorkoutInstance == null)
                {
                    workoutInstance.Id = Guid.NewGuid().ToString();
                    workoutInstance.Active = true;
                    workoutInstance.UserId = UserName;

                    ctx.WorkoutInstances.Add(workoutInstance);

                    //create log for Adding
                    var log = new Log();
                    log.LogId = Guid.NewGuid().ToString();
                    log.Entity = Entities.Enums.Entity.WorkoutInstance;
                    log.PrimaryEntityId = workoutInstance.Id;
                    log.SecondaryEntityId = "-";
                    log.LogDate = DateTime.Now;
                    log.Type = Entities.Enums.Operations.Add;
                    log.Property = "-";
                    log.OldValue = "-";
                    log.NewValue = "-";
                    log.UserId = workoutInstance.UserId;
                    ctx.Logs.Add(log);
                }
                else
                {
                    oldWorkoutInstance.WorkoutId = workoutInstance.WorkoutId;
                    if (workoutInstance.Status == Entities.Enums.StatusType.Planned) {
                        if (workoutInstance.Date != DateTime.MinValue)
                        {
                            if (oldWorkoutInstance.Date != workoutInstance.Date) {
                                //date has been changed => create new log
                                var log = new Log();
                                log.LogId = Guid.NewGuid().ToString();
                                log.Entity = Entities.Enums.Entity.WorkoutInstance;
                                log.PrimaryEntityId = oldWorkoutInstance.Id;
                                log.SecondaryEntityId = "-";
                                log.Type = Entities.Enums.Operations.Modify;
                                log.LogDate = DateTime.Now;
                                log.Property = "Date";
                                log.OldValue = oldWorkoutInstance.Date.ToString("yyyy-MM-dd");
                                log.NewValue = workoutInstance.Date.ToString("yyyy-MM-dd");
                                log.UserId = workoutInstance.UserId;
                                ctx.Logs.Add(log);
                            }
                            oldWorkoutInstance.Date = workoutInstance.Date;
                        }
                    };
                    oldWorkoutInstance.Status = workoutInstance.Status;
                    oldWorkoutInstance.UserId = workoutInstance.UserId;
                    oldWorkoutInstance.Active = workoutInstance.Active;
                    if (oldWorkoutInstance.Rounds != workoutInstance.Rounds) {
                        //Rounds have been changed = create new log
                        var log = new Log();
                        log.LogId = Guid.NewGuid().ToString();
                        log.Entity = Entities.Enums.Entity.WorkoutInstance;
                        log.PrimaryEntityId = oldWorkoutInstance.Id;
                        log.SecondaryEntityId = "-";
                        log.Type = Entities.Enums.Operations.Modify;
                        log.LogDate = DateTime.Now;
                        log.Property = "Rounds";
                        log.OldValue = oldWorkoutInstance.Rounds.ToString();
                        log.NewValue = workoutInstance.Rounds.ToString();
                        log.UserId = workoutInstance.UserId;
                        ctx.Logs.Add(log);
                    }
                    oldWorkoutInstance.Rounds = workoutInstance.Rounds;

                    if (workoutInstance.Status == Entities.Enums.StatusType.Completed)
                    {
                        //complete workout instance
                        var log = new Log();
                        log.LogId = Guid.NewGuid().ToString();
                        log.Entity = Entities.Enums.Entity.WorkoutInstance;
                        log.PrimaryEntityId = oldWorkoutInstance.Id;
                        log.SecondaryEntityId = "-";
                        log.Type = Entities.Enums.Operations.Compleat;
                        log.LogDate = DateTime.Now;
                        log.Property = "Status";
                        log.OldValue = oldWorkoutInstance.Status.ToString();
                        log.NewValue = workoutInstance.Status.ToString();
                        log.UserId = workoutInstance.UserId;
                        ctx.Logs.Add(log);
                       
                    }
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
                        
                        if (oldWorkoutInstanceExercise.PlannedRepetitions != wIE.PlannedRepetitions) {
                            //modify planned repetitions = new log for this inctance exercise
                            var log = new Log();
                            log.LogId = Guid.NewGuid().ToString();
                            log.Entity = Entities.Enums.Entity.WorkoutInstanceExercise;
                            log.PrimaryEntityId = wIE.WorkoutInstanceId;
                            log.SecondaryEntityId = wIE.Id;
                            log.LogDate = DateTime.Now;
                            log.Type = Entities.Enums.Operations.Modify;
                            log.Property = "Planned Repetitions";
                            log.OldValue = oldWorkoutInstanceExercise.PlannedRepetitions.ToString();
                            log.NewValue = wIE.PlannedRepetitions.ToString();
                            log.UserId = workoutInstance.UserId;
                            ctx.Logs.Add(log);

                        }
                        oldWorkoutInstanceExercise.PlannedRepetitions = wIE.PlannedRepetitions;

                        if (oldWorkoutInstanceExercise.ActualRepetitions != wIE.ActualRepetitions)
                        {
                            //complete => new log for completion of instance exercie
                            var log = new Log();
                            log.LogId = Guid.NewGuid().ToString();
                            log.Entity = Entities.Enums.Entity.WorkoutInstanceExercise;
                            log.PrimaryEntityId = wIE.WorkoutInstanceId;
                            log.SecondaryEntityId = wIE.Id;
                            log.LogDate = DateTime.Now;
                            log.Type = Entities.Enums.Operations.Compleat;
                            log.Property = "Actual Repetitions";
                            log.OldValue = oldWorkoutInstanceExercise.ActualRepetitions.ToString();
                            log.NewValue = wIE.ActualRepetitions.ToString();
                            log.UserId = workoutInstance.UserId;
                            ctx.Logs.Add(log);

                        }
                        oldWorkoutInstanceExercise.ActualRepetitions = wIE.ActualRepetitions;

                        if (oldWorkoutInstance.Status == Entities.Enums.StatusType.Completed)
                        {
                           
                            numberOfExercises++;
                            TotalSum = Math.Round(TotalSum + ((oldWorkoutInstanceExercise.ActualRepetitions * 100) / oldWorkoutInstanceExercise.PlannedRepetitions),2);
                        }
                    }
                }
                if (oldWorkoutInstance != null && oldWorkoutInstance.Status == Entities.Enums.StatusType.Completed)
                {
                    
                    oldWorkoutInstance.Percentage = Math.Round(TotalSum / numberOfExercises, 2);
                    if (oldWorkoutInstance.Percentage <= 100.00)
                        oldWorkoutInstance.Points = Math.Round(oldWorkoutInstance.Percentage / 10, 2);
                    else
                    {
                        if (oldWorkoutInstance.Percentage <= 150.00) oldWorkoutInstance.Points = 15;   //10+5
                        else
                          if (oldWorkoutInstance.Percentage <= 200.00) oldWorkoutInstance.Points = 20; //10+10
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
                    var log = new Log();
                    log.LogId = Guid.NewGuid().ToString();
                    log.Entity = Entities.Enums.Entity.WorkoutInstance;
                    log.PrimaryEntityId = workoutInstance.Id;
                    log.SecondaryEntityId = "-";
                    log.LogDate = DateTime.Now;
                    log.Type = Entities.Enums.Operations.Delete;
                    log.Property = "-";
                    log.OldValue = "-";
                    log.NewValue = "-";
                    ctx.Logs.Add(log);

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