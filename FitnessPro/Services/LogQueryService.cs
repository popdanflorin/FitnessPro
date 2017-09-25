using FitnessPro.Entities;
using FitnessPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessPro.Services
{
    public class LogQueryService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        public List<Log> GetLogs(string UserName)
        {
            return ctx.Logs.Where(wie => wie.UserId == UserName).ToList();
        }
    }
}