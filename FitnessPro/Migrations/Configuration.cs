namespace FitnessPro.Migrations
{
    using FitnessPro.Entities;
    using FitnessPro.Entities.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FitnessPro.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FitnessPro.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Workouts.AddOrUpdate(
              p => p.Name,
              new Workout { Id = Guid.NewGuid().ToString(), Name = "Six-pack in six weeks", Description = "All you need to get ripped is three workouts and an iron will.", Type = WorkoutType.Abs, Active = true },
              new Workout { Id = Guid.NewGuid().ToString(), Name = "High intensity chest-to-legs circuit", Description = "Take advantage of just one piece of equipment—a medicine ball—and your own bodyweight to get a muscle burn from your pecs all the way down to your quads.", Type = WorkoutType.Chest, Active = true },
              new Workout { Id = Guid.NewGuid().ToString(), Name = "The pullup-pushup workout routine", Description = "Lock down a great upper body with the only two exercises you really needs.", Type = WorkoutType.Chest, Active = true }

            );
        }
    }
}
