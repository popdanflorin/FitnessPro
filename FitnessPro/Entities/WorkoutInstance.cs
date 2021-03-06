﻿using FitnessPro.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessPro.Entities
{
    public class WorkoutInstance
    {
        public string Id { get; set; }
        public string WorkoutId { get; set; }
        public DateTime Date { get; set; }
        public StatusType Status { get; set; }
        public string UserId { get; set; }
        public Boolean Active { get; set; }
        public int Rounds { get; set; }
        public double Percentage { get; set;  }
        public double Points { get; set; }
        public string StatusDisplay
        {
            get {
                return Status.ToString();
            }

        }
        
        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }

        public string WorkoutName
        {
            get
            {
                return Workout.Name; 
            }
        }
    }
}