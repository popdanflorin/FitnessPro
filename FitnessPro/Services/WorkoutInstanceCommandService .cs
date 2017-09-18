﻿using FitnessPro.Entities;
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
                    ctx.WorkoutInstances.Add(workoutInstance);
                }
                else
                {
                    oldWorkoutInstance.WorkoutId = workoutInstance.WorkoutId;
                    if (workoutInstance.Status == Entities.Enums.StatusType.Planned) {
                        oldWorkoutInstance.Date = workoutInstance.Date;
                    };
                    oldWorkoutInstance.Status = workoutInstance.Status;
                    oldWorkoutInstance.UserId = workoutInstance.UserId;
                }

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
                        oldWorkoutInstanceExercise.WorkoutInstanceId = oldWorkoutInstance.Id;
                        oldWorkoutInstanceExercise.Id = wIE.Id;
                        oldWorkoutInstanceExercise.ExerciseName = wIE.ExerciseName;
                        oldWorkoutInstanceExercise.ExerciseId = wIE.ExerciseId;
                        oldWorkoutInstanceExercise.PlannedRepetitions = wIE.PlannedRepetitions;
                        oldWorkoutInstanceExercise.ActualRepetitions = wIE.ActualRepetitions;
                       
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
                    ctx.WorkoutInstanceExercises.RemoveRange(wIExercises);
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