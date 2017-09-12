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
                case WorkoutType.Arms: return "Arms";
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
    }
}