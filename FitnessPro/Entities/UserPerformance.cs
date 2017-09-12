using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessPro.Entities
{
    public class UserPerformance
    {
        public string Id { get; set; }
        public string WorkoutInstanceId { get; set; }
        public int Points { get; set; }
        //trebuie PointsDisplay? (->to string)
        [ForeignKey("WorkoutInstanceId")]
        public WorkoutInstance WorkoutInstance { get; set; }
    }
}