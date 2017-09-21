using FitnessPro.Entities;
using FitnessPro.Entities.Enums;
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
        private const string AddWorkoutMessage = "You can't add a workout if you dont add a name .";
        
        public string SaveWorkout(Workout workout)
        {
            try
            {
                var oldWorkout = ctx.Workouts.FirstOrDefault(f => f.Id == workout.Id);
                var log = new Log();
                log.LogId = Guid.NewGuid().ToString();
                log.Entity = Entity.Workout;
                log.PrimaryEntityId = workout.Id;
                if (oldWorkout == null)
                {//add
                    workout.Id = Guid.NewGuid().ToString();
                    
                    //logdata pentru modify ramane acelasi si la modify(ceea ce am deja salvat modific
                    log.LogDate = DateTime.Today;
                    log.Type = Operations.Add;
                  

                    workout.Active = true;
                    ctx.Workouts.Add(workout);
                    
                    

                }
                else
                {//modify
                    if (workout.Name != null || workout.Description != null)
                    {
                        oldWorkout.Name = workout.Name;
                        oldWorkout.Description = workout.Description;
                        oldWorkout.Type = workout.Type;
                        log.Type = Operations.Modify;
                        log.Property = "Date";
                        log.OldValue = log.LogDate;
                        log.NewValue = DateTime.Today;





                    }
                    else
                    {
                        return AddWorkoutMessage;
                    }
                }

                ctx.SaveChanges();
                ctx.Logs.Add(log);
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
                var log = new Log();
                if (workout != null)
                {
                    var exercises = ctx.WorkoutExercises.Where(we => we.WorkoutId == workout.Id);
                    workout.Active = false;
                    log.LogId = Guid.NewGuid().ToString();
                    log.Entity = Entity.Workout;
                    log.PrimaryEntityId = workout.Id;
                    log.LogDate = DateTime.Today;
                    log.Type = Operations.Delete;
                    //ctx.WorkoutExercises.RemoveRange(exercises);
                    //ctx.Workouts.Remove(workout);
                    
                    ctx.SaveChanges();
                    ctx.Logs.Add(log);
                    return SuccessMessage;
                }
                return ItemNotFoundMessage;
            }
            catch (Exception ex)
            {
                return ErrorMessage;
            }
        }
        //save workoutexercise
        public string SaveWorkoutexercise(WorkoutExercise exercise)
        {
            try
            {
                var oldexercise = ctx.WorkoutExercises.FirstOrDefault(f => f.Id == exercise.Id);
                if (oldexercise == null)
                {
                    exercise.Id = Guid.NewGuid().ToString();
                    exercise.ActiveEx = true;
                    ctx.WorkoutExercises.Add(exercise);
                }
                else
                {
                    oldexercise.Name = exercise.Name;
                    oldexercise.Description = exercise.Description;
                    oldexercise.Repetitions = exercise.Repetitions;
                }

                ctx.SaveChanges();
                return SuccessMessage;
            }
            catch
            {
                return ErrorMessage;
            }
        }
        //delete WorkoutExercise
        public string DeleteWorkoutExercise(string id)
        {
            try
            {
                var exercise = ctx.WorkoutExercises.FirstOrDefault(f => f.Id == id);
                if (exercise != null)
                {
                    //ctx.WorkoutExercises.Remove(exercise);
                    exercise.ActiveEx = false;
                    ctx.SaveChanges();
                    return SuccessMessage;
                }
                return ItemNotFoundMessage;
            }
            catch (Exception ex)
            {
                return ErrorMessage;
            }
        }
    }
}