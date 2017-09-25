using System;
using FitnessPro.Entities.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPro.Entities
{
    public class Log
    {
        public string LogId { get; set; }
        public Entity Entity { get; set; }
        public string PrimaryEntityId { get; set; }
        public string SecondaryEntityId { get; set; }
        public DateTime LogDate { get; set; }
        public  Operations Type { get; set; }
        public string Property { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string EntitieTypes
        {
            get
            {
                return Entity.ToString();
            }
        }
        public string OperationTypes
        {
            get
            {
                return Type.ToString();
            }
        }
        [NotMapped]
        public string ExerciseName { get; set;  }


    }
}