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
              new Workout { Id = Guid.NewGuid().ToString(), Name = "The bigger, stronger back workout", Description = "- Get a more substantial back in four weeks with this training program targeting every muscle system behind you.", Type = WorkoutType.Back, Active = true },
              new Workout { Id = Guid.NewGuid().ToString(), Name = "High intensity chest-to-legs circuit", Description = "Take advantage of just one piece of equipment—a medicine ball—and your own bodyweight to get a muscle burn from your pecs all the way down to your quads.", Type = WorkoutType.Chest, Active = true },
              new Workout { Id = Guid.NewGuid().ToString(), Name = "The pullup-pushup workout routine", Description = "Lock down a great upper body with the only two exercises you really needs.", Type = WorkoutType.Chest, Active = true }
              

            );
            context.SaveChanges();
            context.WorkoutExercises.AddOrUpdate(
                p => p.Name,
                //ex for Six-pack in six weeks
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Ab Crunch", Description = "Begins with lying face up on the floor with knees bent. The movement begins by curling the shoulders towards the pelvis. The hands can be behind or beside the neck or crossed over the chest.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "Six-pack in six weeks").Id, ActiveEx = true, Repetitions = 50 },
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Hanging Leg Raise", Description = "Hang from a chin-up bar with both arms extended at arms length in top of you using either a wide grip or a medium grip. Raise your legs until the torso makes a 90-degree angle with the legs. Go back slowly to the starting position.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "Six-pack in six weeks").Id, ActiveEx = true, Repetitions = 40 },
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Knee Raise ", Description = "Start by lying on your back with your arms next to your sides and your legs extended. Tighten your abdominals and raise your feet and legs about 3 inches off the floor to come into the starting position. Bend your knees and pull them into your chest as far as you can. Reverse the motion and return your legs to the starting position.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "Six-pack in six weeks").Id, ActiveEx = true, Repetitions = 30 },
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Sit Up", Description = "Lay down with your knees bent and your feet placed flat on the ground. Cross your arms over your chest so your hands touch the opposite shoulders. Tighten your abdominal muscles. Draw your belly button in to your spine. Slowly sit up. Bring your head up first, then your shoulders. Keep your feet on the ground. Hold the position for a second. Slowly lay back down.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "Six-pack in six weeks").Id, ActiveEx = true, Repetitions = 50 },

                //ex for The bigger, stronger back workout
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Barbell deadlift", Description = "Bend at hips and knees, and grab a loaded barbell with an overhand grip about twice as wide as shoulder-width. Without allowing your lower back to round, stand up and thrust your hips forward as you squeeze your glutes. Pause, then lower the bar back to the floor while keeping it as close to your body as possible.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "The bigger, stronger back workout").Id, ActiveEx = true, Repetitions = 50 },
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Rack pull", Description = "Place a barbell on a squat rack just above your knees. Stand with your feet shoulder-width apart and bend at your knees, leaning slightly forward at hips to grab the bar with one palm facing away and the other facing inward. Quickly extend your knees and hips, pulling the weight up and back until your body completely locks out. Pause, then return the bar back to the starting position.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "The bigger, stronger back workout").Id, ActiveEx = true, Repetitions = 60 },

                 //ex for High intensity chest-to-legs circuit
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Medicine ball pushup", Description = "Bend at hips and knees, and grab a loaded barbell with an overhand grip about twice as wide as shoulder-width. Without allowing your lower back to round, stand up and thrust your hips forward as you squeeze your glutes. Pause, then lower the bar back to the floor while keeping it as close to your body as possible.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "High intensity chest-to-legs circuit").Id, ActiveEx = true, Repetitions = 50 },
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Medicine Ball Russian Twist", Description = "Place a barbell on a squat rack just above your knees. Stand with your feet shoulder-width apart and bend at your knees, leaning slightly forward at hips to grab the bar with one palm facing away and the other facing inward. Quickly extend your knees and hips, pulling the weight up and back until your body completely locks out. Pause, then return the bar back to the starting position.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "High intensity chest-to-legs circuit").Id, ActiveEx = true, Repetitions = 60 },
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Plyo Pushup", Description = "Bend at hips and knees, and grab a loaded barbell with an overhand grip about twice as wide as shoulder-width. Without allowing your lower back to round, stand up and thrust your hips forward as you squeeze your glutes. Pause, then lower the bar back to the floor while keeping it as close to your body as possible.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "High intensity chest-to-legs circuit").Id, ActiveEx = true, Repetitions = 50 },

                 //ex for The pullup-pushup workout routine
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Feet-Elevated Pushup", Description = "Get into pushup position and place your feet on a bench or box. Lower your body until your chest is just above the floor, and then push up.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "The pullup-pushup workout routine").Id, ActiveEx = true, Repetitions = 30 },
                new WorkoutExercise { Id = Guid.NewGuid().ToString(), Name = "Rack pull", Description = "Grab a pullup bar underhand at shoulder width.", WorkoutId = context.Workouts.FirstOrDefault(w => w.Name == "The pullup-pushup workout routine").Id, ActiveEx = true, Repetitions = 45 }

                );
        }
    }
}
