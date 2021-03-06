﻿using FitnessPro.Entities;
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

        //am modificat
        public List<Workout> GetWorkouts()   
        {
            // var workouts = ctx.Workouts.ToList();
            //active
            //return workouts;
            return ctx.Workouts.Where(wie => wie.Active == true).ToList();
        }
        public List<WorkoutExercise> GetExercises(string workoutid)
        {
            return ctx.WorkoutExercises.Where(x => x.WorkoutId == workoutid &&  x.ActiveEx == true).ToList(); 
            //active
        }
        public List<EnumItem> GetWorkoutTypes()
        {
            return Enum.GetValues(typeof(WorkoutType)).Cast<WorkoutType>().Select(x => new EnumItem() { Id = (int)x, Description = x.ToString() }).ToList();
        }
        public List<Log> GetAllOpForWorkout(string workoutid)
        {
            var logs =  ctx.Logs.Where(x => x.PrimaryEntityId == workoutid).ToList();
            foreach (var item in logs)
            {
             if (item.SecondaryEntityId != null)
                {
                    item.ExerciseName = ctx.WorkoutExercises.FirstOrDefault(w => w.Id == item.SecondaryEntityId).Name;
                }
            }
            return logs;
            //active
        }
      

    }
}