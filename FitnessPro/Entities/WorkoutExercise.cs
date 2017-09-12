using FitnessPro.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessPro.Entities
{
    public class WorkoutExercise
    {
        public string Id { get; set; }
        public string WorkoutId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Repetitions { get; set; }
        //def contrangere de tip foreignkey 
        [ForeignKey("WorkoutId")]
        public virtual Workout Workout { get; set; }
    }
}