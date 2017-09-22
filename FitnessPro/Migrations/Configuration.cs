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
            context.WorkoutExercises.AddOrUpdate(
                p => p.Name,
                //new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Ab Crunch", Description = "Begins with lying face up on the floor with knees bent. The movement begins by curling the shoulders towards the pelvis. The hands can be behind or beside the neck or crossed over the chest.", WorkoutId = context.Workouts.Where(w => w.Name ==  "Six-pack in six weeks").Id, ActiveEx = true, Repetitions = 50 },
                //trebuie luata Id-ul workoutului cumva unde numele este "Six..."
                //new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Hanging Leg Raise", Description = "Hang from a chin-up bar with both arms extended at arms length in top of you using either a wide grip or a medium grip. Raise your legs until the torso makes a 90-degree angle with the legs. Go back slowly to the starting position.", WorkoutId = "617b8405-e2bf-4ae2-81f4-4a03b9ba97e5", ActiveEx = true, Repetitions = 40 },
                //new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Knee Raise ", Description = "Start by lying on your back with your arms next to your sides and your legs extended. Tighten your abdominals and raise your feet and legs about 3 inches off the floor to come into the starting position. Bend your knees and pull them into your chest as far as you can. Reverse the motion and return your legs to the starting position.", WorkoutId = "617b8405-e2bf-4ae2-81f4-4a03b9ba97e5", ActiveEx = true, Repetitions = 30 },
                //new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Sit Up", Description = "Lay down with your knees bent and your feet placed flat on the ground. Cross your arms over your chest so your hands touch the opposite shoulders. Tighten your abdominal muscles. Draw your belly button in to your spine. Slowly sit up. Bring your head up first, then your shoulders. Keep your feet on the ground. Hold the position for a second. Slowly lay back down.", WorkoutId = "617b8405-e2bf-4ae2-81f4-4a03b9ba97e5", ActiveEx = true, Repetitions = 50 }
                
                );
        }
    }
}
