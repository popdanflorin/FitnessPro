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
        private const string DateTimeFormat = "yyyyMMddHHmmss";

        public string SaveWorkout(Workout workout)
        {
            try
            {
                var oldWorkout = ctx.Workouts.FirstOrDefault(f => f.Id == workout.Id);
                var logs = new List<Log>();

                if (oldWorkout == null)
                {
                    var log = InitLog();
                    //add
                    workout.Id = Guid.NewGuid().ToString();
                    workout.Active = true;

                    log.PrimaryEntityId = workout.Id;
                    log.Type = Operations.Add;
                    logs.Add(log);

                    ctx.Workouts.Add(workout);
                }
                else
                {
                    //modify
                    if (workout.Name != null || workout.Description != null)
                    {
                        if (oldWorkout.Name != workout.Name)
                        {
                            var log = InitLog();
                            log.PrimaryEntityId = workout.Id;
                            log.Type = Operations.Modify;
                            log.Property = "Name";
                            log.OldValue = oldWorkout.Name;
                            log.NewValue = workout.Name;
                            logs.Add(log);
                            oldWorkout.Name = workout.Name;
                        }
                        if (oldWorkout.Description != workout.Description)
                        {
                            var log = InitLog();
                            log.PrimaryEntityId = workout.Id;
                            log.Type = Operations.Modify;
                            log.Property = "Description";
                            log.OldValue = oldWorkout.Description;
                            log.NewValue = workout.Description;
                            logs.Add(log);
                            oldWorkout.Description = workout.Description;
                        }
                        if (oldWorkout.Type != workout.Type)
                        {
                            var log = InitLog();
                            log.PrimaryEntityId = workout.Id;
                            log.Type = Operations.Modify;
                            log.Property = "Type";
                            log.OldValue = oldWorkout.TypeDisplay;
                            log.NewValue = workout.TypeDisplay;
                            logs.Add(log);
                            oldWorkout.Type = workout.Type;
                        }
                    }
                    else
                    {
                        return AddWorkoutMessage;
                    }
                }
                ctx.Logs.AddRange(logs);
                ctx.SaveChanges();

                return SuccessMessage;
            }
            catch (Exception ex)
            {
                return ErrorMessage;
            }
        }

        private Log InitLog()
        {
            var log = new Log();
            log.LogId = Guid.NewGuid().ToString();
            log.Entity = Entity.Workout;
            log.LogDate = DateTime.Now;
            return log;
        }
        private Log InitLogEx()
        {
            var log = new Log();
            log.LogId = Guid.NewGuid().ToString();
            log.Entity = Entity.WorkoutExercise;
            log.LogDate = DateTime.Now;
            return log;
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
                    log.LogDate = DateTime.Now;
                    log.Type = Operations.Delete;
                    //ctx.WorkoutExercises.RemoveRange(exercises);
                    //ctx.Workouts.Remove(workout);
                    ctx.Logs.Add(log);
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
        //save workoutexercise
        public string SaveWorkoutexercise(WorkoutExercise exercise)
        {
            try
            {
                var oldexercise = ctx.WorkoutExercises.FirstOrDefault(f => f.Id == exercise.Id);
                var logs = new List<Log>();

               

                if (oldexercise == null)
                {
                    var log = InitLogEx();
                    //add
                    exercise.Id = Guid.NewGuid().ToString();
                    exercise.ActiveEx = true;

                    log.PrimaryEntityId = exercise.WorkoutId;
                    log.SecondaryEntityId = exercise.Id;
                    log.Type = Operations.Add;
                    logs.Add(log);

                    ctx.WorkoutExercises.Add(exercise);
                }
                else
                {
                    //modify
                    if (exercise.Name != null || exercise.Description != null)
                    {
                        if (oldexercise.Name != exercise.Name)
                        {
                            var log = InitLogEx();
                            log.PrimaryEntityId = exercise.WorkoutId;
                            log.SecondaryEntityId = exercise.Id;
                            log.Type = Operations.Modify;
                            log.Property = "Name";
                            log.OldValue = oldexercise.Name;
                            log.NewValue = exercise.Name;
                            logs.Add(log);
                            oldexercise.Name = exercise.Name;
                        }
                        if (oldexercise.Description != exercise.Description)
                        {
                            var log = InitLogEx();
                            log.PrimaryEntityId = exercise.WorkoutId;
                            log.SecondaryEntityId = exercise.Id;
                            log.Type = Operations.Modify;
                            log.Property = "Description";
                            log.OldValue = oldexercise.Description;
                            log.NewValue = exercise.Description;
                            logs.Add(log);
                            oldexercise.Description = exercise.Description;
                        }
                        if (oldexercise.Repetitions != exercise.Repetitions)
                        {
                            var log = InitLogEx();
                            log.PrimaryEntityId = exercise.WorkoutId;
                            log.SecondaryEntityId = exercise.Id;
                            log.Type = Operations.Modify;
                            log.Property = "repetitions";
                            log.OldValue = oldexercise.Repetitions.ToString();
                            log.NewValue = exercise.Repetitions.ToString();
                            logs.Add(log);
                            oldexercise.Repetitions = exercise.Repetitions;
                        }
                    }
                    else
                    {
                        return AddWorkoutMessage;
                    }
                }
                ctx.Logs.AddRange(logs);

                ctx.SaveChanges();

                return SuccessMessage;
            }
            catch (Exception ex)
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
                var log = new Log();
                if (exercise != null)
                {
                    //ctx.WorkoutExercises.Remove(exercise);
                    log.LogId = Guid.NewGuid().ToString();
                    log.Entity = Entity.WorkoutExercise;
                    log.PrimaryEntityId = exercise.WorkoutId;
                    log.SecondaryEntityId = exercise.Id;
                    log.LogDate = DateTime.Now;
                    log.Type = Operations.Delete;
                    exercise.ActiveEx = false;
                    ctx.Logs.Add(log);
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