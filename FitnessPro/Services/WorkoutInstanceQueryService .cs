﻿using FitnessPro.Entities;
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
        private WorkoutQueryService qService = new WorkoutQueryService();

        public List<Workout> GetWorkouts()
        {
            return ctx.Workouts.Where(wie => wie.Active == true).ToList();
        }
        public List<WorkoutExercise> GetExercises()
        {
            return ctx.WorkoutExercises.Where(wie => wie.ActiveEx == true).ToList(); 
        }
        public List<WorkoutInstance> GetWorkoutInstances(string userName) {
            return ctx.WorkoutInstances.Include("Workout").Where(wie => wie.Active == true && wie.UserId == userName ).ToList();
        }
        public List<WorkoutInstance> GetCompletedWorkoutInstances(string userName) {
            return ctx.WorkoutInstances.Include("Workout").Where(wie => wie.Status == Entities.Enums.StatusType.Completed && wie.UserId == userName).ToList();
        }
        public List<WorkoutInstanceExercise> GetWorkoutInstanceExercises(string workoutInstanceId) {
            var exercises = ctx.WorkoutExercises.ToList();
            var wiex = ctx.WorkoutInstanceExercises.Where(wix => (wix.WorkoutInstanceId == workoutInstanceId) &&( wix.Active == true)).ToList();
            foreach (var item in wiex)
            {
                item.ExerciseName = exercises.FirstOrDefault(e => e.Id == item.ExerciseId).Name;
            }
            return wiex;
        }
        public List<WorkoutInstanceExercise> GetWorkoutExercisesForCreation(string workoutId)
        {
            var exercises = qService.GetExercises(workoutId);
            var result = new List<WorkoutInstanceExercise>();
            foreach (var ex in exercises)
            {
                var wie = new WorkoutInstanceExercise();
                wie.Id = Guid.NewGuid().ToString();
                wie.ExerciseId = ex.Id;
                wie.ExerciseName = ex.Name;
                wie.PlannedRepetitions = ex.Repetitions;
                wie.Active = true;
                result.Add(wie);
            }
            return result;
        }
        public List<EnumItem> GetWorkoutStatuses()
        {
            return Enum.GetValues(typeof(StatusType)).Cast<StatusType>().Select(x => new EnumItem() { Id = (int)x, Description = x.ToString() }).ToList();
        }
        public double GetTotalPercentage(List<WorkoutInstance> completedWorkoutInstances)
        {
            var totalPercentageSum = 0.0;
            foreach (var cWI in completedWorkoutInstances)
            {
                totalPercentageSum += cWI.Percentage;
            }
            return (totalPercentageSum / completedWorkoutInstances.Count);
        }
        public double GetTotalPoints(List<WorkoutInstance> completedWorkoutInstances)
        {
            var totalPoints = 0.0;
            foreach (var cWI in completedWorkoutInstances)
            {
                totalPoints += cWI.Points;
            }
            return totalPoints;
        }
        public List<WorkoutInstance> GetCompletedWorkoutInstances_DatePercentageList(string userName)
        {
            var cmpList = ctx.WorkoutInstances.Include("Workout").Where(wie => wie.Status == Entities.Enums.StatusType.Completed && wie.UserId == userName).ToList();
            var datePercentageList = new List<WorkoutInstance> ();
            foreach (var wI in cmpList) {
                //dateList: all the entities with the date of wI.Date
                var dateList = cmpList.Where(w => w.Date == wI.Date).ToList();
                var percentage = 0.0;
                foreach (var i in dateList) {
                    percentage += i.Percentage;
                }
                percentage = percentage / (dateList.Count());
                var workoutInstance = new WorkoutInstance();
                workoutInstance.Id = Guid.NewGuid().ToString();
                workoutInstance.Date = wI.Date;
                workoutInstance.Percentage = percentage;
                workoutInstance.Status = StatusType.Planned;
                workoutInstance.Workout = wI.Workout;
                workoutInstance.WorkoutId = wI.WorkoutId;
                datePercentageList.Add(workoutInstance);
            }
            //eliminate duplicates by Date field
            for (var i = 0; i< datePercentageList.Count(); i++) {
                for (var j = i+1; j < datePercentageList.Count(); j++) {
                    if (datePercentageList[j].Date == datePercentageList[i].Date) {
                        datePercentageList.RemoveAt(j);
                    }
                }
            }
            return datePercentageList;
        }
    }
}