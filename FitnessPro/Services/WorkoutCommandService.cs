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
        private const string AddWorkoutMessage = "you can't add a workout if you dont add a name ,a description and a type.";
        public string SaveWorkout(Workout workout)
        {
            try
            {
                var oldWorkout = ctx.Workouts.FirstOrDefault(f => f.Id == workout.Id);
                if (oldWorkout == null)
                {
                    workout.Id = Guid.NewGuid().ToString();
                    workout.Active = true;
                    ctx.Workouts.Add(workout);

                }
                else
                {
                    if (workout.Name != null || workout.Description != null)
                    {
                        oldWorkout.Name = workout.Name;
                        oldWorkout.Description = workout.Description;
                        oldWorkout.Type = workout.Type;
                    }
                    else
                    {
                        return AddWorkoutMessage;
                    }
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
                    var exercises = ctx.WorkoutExercises.Where(we => we.WorkoutId == workout.Id);
                    workout.Active = false;
                    //ctx.WorkoutExercises.RemoveRange(exercises);
                    //ctx.Workouts.Remove(workout);
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