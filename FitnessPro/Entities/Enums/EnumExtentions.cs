using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessPro.Entities.Enums
{
    public static class EnumExtensions
    {
        public static string ToString(this WorkoutType type)
        {
            switch (type)
            {
                case WorkoutType.Abs: return "Abs";
                case WorkoutType.Biceps: return "Biceps";
                case WorkoutType.Triceps: return "Triceps";
                case WorkoutType.Back: return "Back";
                case WorkoutType.Chest: return "Chest";
                case WorkoutType.Legs: return "Legs";
                case WorkoutType.Shoulders: return "Shoulders";

                default: return String.Empty;
            }
        }
        public static string ToString(this StatusType type)
        {
            switch (type)
            {
                case StatusType.Planned: return "Planned";
                case StatusType.Completed: return "Completed";
                
                default: return String.Empty;
            }
        }
        public static string ToString(this Operations type)
        {
            switch (type)
            {
                case Operations.Add: return "Add";
                case Operations.Delete: return "Delete";
                case Operations.Compleat: return "Compleat";
                case Operations.Modify: return "Modify";
                

                default: return String.Empty;
            }
        }
        public static string ToString(this Entity type)
        {
            switch (type)
            {
                case Entity.Workout: return "Workout";
                case Entity.WorkoutExercise: return "WorkoutExercise";
                case Entity.WorkoutInstance: return "WorkoutInstance";




                default: return String.Empty;
            }
        }
    }
}