using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessPro.Entities
{
    public class WorkoutInstanceExercise
    {
        public string Id { get; set; }
        public string WorkoutInstanceId { get; set; }
        public string ExerciseId { get; set; }
        [NotMapped]
        public string ExerciseName { get; set; }
        public int PlannedRepetitions { get; set; }
        public int ActualRepetitions { get; set; }
        //trebuie PlannedRepetitions -> to string pentru display?
        //trebuie ActualRtions -> to string pentru display?
        [ForeignKey("WorkoutInstanceId")]
        public WorkoutInstance WorkoutInstance { get; set; }
        [ForeignKey("ExerciseId")]
        public WorkoutExercise WorkoutExercise { get; set; }
    }
}