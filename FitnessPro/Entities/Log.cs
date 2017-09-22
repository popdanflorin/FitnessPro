﻿using System;
using FitnessPro.Entities.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessPro.Entities
{
    public class Log
    {
        public string LogId { get; set; }
        public Entity Entity { get; set; }
        public string PrimaryEntityId { get; set; }
        public string SecondaryEntityId { get; set; }
        public DateTime? LogDate { get; set; }
        public  Operations Type { get; set; }
        public string Property { get; set; }
        public DateTime? OldValue { get; set; }
        public DateTime? NewValue { get; set; }
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



    }
}