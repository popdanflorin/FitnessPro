using FitnessPro.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessPro.Entities
{
    public class Workout
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkoutType Type { get; set; }
        public string TypeDisplay
        {
            get
            {
                return Type.ToString();
            }
        }
    }
}