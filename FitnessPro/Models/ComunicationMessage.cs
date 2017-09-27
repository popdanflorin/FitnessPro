using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessPro.Models
{
    public class CommunicationMessage
    {
        public string Message { get; set; }
        public MessageType Type { get; set; }
    }

    public enum MessageType
    {
        Succes,
        Error,
    }
}