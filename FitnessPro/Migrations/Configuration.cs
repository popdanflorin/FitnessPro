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

            var absWorkout = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Six-pack in six weeks",
                Description = "All you need to get ripped is three workouts and an iron will.",
                Type = WorkoutType.Abs,
                Active = true
            };
            var backWorkout = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "The bigger, stronger back workout",
                Description = "Get a more substantial back in four weeks with this training program targeting every muscle system behind you.",
                Type = WorkoutType.Back,
                Active = true
            };
            var chestWorkout1 = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "High intensity chest-to-legs circuit",
                Description = "Take advantage of just one piece of equipment—a medicine ball—and your own bodyweight to get a muscle burn from your pecs all the way down to your quads.",
                Type = WorkoutType.Chest,
                Active = true
            };
            var chestWorkout2 = new Workout {
                Id = Guid.NewGuid().ToString(),
                Name = "The pullup-pushup workout routine",
                Description = "Lock down a great upper body with the only two exercises you really needs.",
                Type = WorkoutType.Chest,
                Active = true
            };

            context.Workouts.AddOrUpdate(p => p.Name, absWorkout, backWorkout, chestWorkout1, chestWorkout2);

            var absEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Ab Crunch",
                Description = "Begins with lying face up on the floor with knees bent. The movement begins by curling the shoulders towards the pelvis. The hands can be behind or beside the neck or crossed over the chest.",
                WorkoutId = absWorkout.Id,
                ActiveEx = true,
                Repetitions = 50
            };
            var absEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Hanging Leg Raise",
                Description = "Hang from a chin-up bar with both arms extended at arms length in top of you using either a wide grip or a medium grip. Raise your legs until the torso makes a 90-degree angle with the legs. Go back slowly to the starting position.",
                WorkoutId = absWorkout.Id,
                ActiveEx = true,
                Repetitions = 40
            };
            var absEx3 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Knee Raise ",
                Description = "Start by lying on your back with your arms next to your sides and your legs extended. Tighten your abdominals and raise your feet and legs about 3 inches off the floor to come into the starting position. Bend your knees and pull them into your chest as far as you can. Reverse the motion and return your legs to the starting position.",
                WorkoutId = absWorkout.Id,
                ActiveEx = true,
                Repetitions = 30
            };
            var absEx4 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Sit Up",
                Description = "Lay down with your knees bent and your feet placed flat on the ground. Cross your arms over your chest so your hands touch the opposite shoulders. Tighten your abdominal muscles. Draw your belly button in to your spine. Slowly sit up. Bring your head up first, then your shoulders. Keep your feet on the ground. Hold the position for a second. Slowly lay back down.",
                WorkoutId = absWorkout.Id,
                ActiveEx = true,
                Repetitions = 50
            };

            var backEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Barbell deadlift",
                Description = "Bend at hips and knees, and grab a loaded barbell with an overhand grip about twice as wide as shoulder-width. Without allowing your lower back to round, stand up and thrust your hips forward as you squeeze your glutes. Pause, then lower the bar back to the floor while keeping it as close to your body as possible.",
                WorkoutId = backWorkout.Id,
                ActiveEx = true,
                Repetitions = 50
            };
            var backEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Rack pull",
                Description = "Place a barbell on a squat rack just above your knees. Stand with your feet shoulder-width apart and bend at your knees, leaning slightly forward at hips to grab the bar with one palm facing away and the other facing inward. Quickly extend your knees and hips, pulling the weight up and back until your body completely locks out. Pause, then return the bar back to the starting position.",
                WorkoutId = backWorkout.Id,
                ActiveEx = true,
                Repetitions = 60
            };

            var chestEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Medicine ball pushup",
                Description = "Bend at hips and knees, and grab a loaded barbell with an overhand grip about twice as wide as shoulder-width. Without allowing your lower back to round, stand up and thrust your hips forward as you squeeze your glutes. Pause, then lower the bar back to the floor while keeping it as close to your body as possible.",
                WorkoutId = chestWorkout1.Id,
                ActiveEx = true,
                Repetitions = 50
            };
            var chestEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Medicine Ball Russian Twist",
                Description = "Place a barbell on a squat rack just above your knees. Stand with your feet shoulder-width apart and bend at your knees, leaning slightly forward at hips to grab the bar with one palm facing away and the other facing inward. Quickly extend your knees and hips, pulling the weight up and back until your body completely locks out. Pause, then return the bar back to the starting position.",
                WorkoutId = chestWorkout1.Id,
                ActiveEx = true,
                Repetitions = 60
            };
            var chestEx3 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Plyo Pushup", Description = "Bend at hips and knees, and grab a loaded barbell with an overhand grip about twice as wide as shoulder-width. Without allowing your lower back to round, stand up and thrust your hips forward as you squeeze your glutes. Pause, then lower the bar back to the floor while keeping it as close to your body as possible.",
                WorkoutId = chestWorkout1.Id,
                ActiveEx = true,
                Repetitions = 50
            };
            var chestEx4 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Feet-Elevated Pushup",
                Description = "Get into pushup position and place your feet on a bench or box. Lower your body until your chest is just above the floor, and then push up.",
                WorkoutId = chestWorkout2.Id,
                ActiveEx = true,
                Repetitions = 30
            };
            var chestEx5 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Chinup",
                Description = "Grab a pullup bar underhand at shoulder width.",
                WorkoutId = chestWorkout2.Id,
                ActiveEx = true,
                Repetitions = 45
            };

            context.SaveChanges();
            context.WorkoutExercises.AddOrUpdate(p => p.Name, absEx1, absEx2, absEx3, absEx4, backEx1, backEx2, chestEx1, chestEx2, chestEx3, chestEx4, chestEx5);
        }
    }
}
