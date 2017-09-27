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

            #region "Piept"

            var chestWorkout = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Antrenament piept",
                Description = "Grupe de muschi afectate: pectoralis major si pectoralis minor",
                Type = WorkoutType.Chest,
                Active = true
            };

            var chestEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Impins din culcat cu bara dreapta",
                Description = "",
                WorkoutId = chestWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var chestEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Impins din inclinat cu bara dreapta",
                Description = "",
                WorkoutId = chestWorkout.Id,
                ActiveEx = true,
                Repetitions = 8
            };

            var chestEx3 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Fluturari cu gantere",
                Description = "",
                WorkoutId = chestWorkout.Id,
                ActiveEx = true,
                Repetitions = 8
            };

            #endregion

            #region "Spate"

            var backWorkout = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Antrenament spate",
                Description = "Grupe de muschi afectate: marele dorsal, trapezul, romboizii, erectorii spinali, lombarii.",
                Type = WorkoutType.Back,
                Active = true
            };

            var backEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Tractiuni cu priza larga",
                Description = "",
                WorkoutId = backWorkout.Id,
                ActiveEx = true,
                Repetitions = 5
            };

            var backEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Ramat la scripete",
                Description = "",
                WorkoutId = backWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var backEx3 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Deadlift",
                Description = "",
                WorkoutId = backWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            #endregion

            #region "Picioare"

            var legsWorkout = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Antrenament picioare",
                Description = "Grupe de muschi afectate: cvadriceps, bicepsul femural, fesieri, adductori, gambelor",
                Type = WorkoutType.Legs,
                Active = true
            };

            var legsEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Presa pentru picioare",
                Description = "",
                WorkoutId = legsWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var legsEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Genuflexiuni cu gantera",
                Description = "",
                WorkoutId = legsWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var legsEx3 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Fandari cu genterele",
                Description = "",
                WorkoutId = legsWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            #endregion

            #region "Biceps"

            var bicepsWorkout = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Antrenament biceps",
                Description = "Grupe de muschi afectate: biceps, biceps brahial",
                Type = WorkoutType.Biceps,
                Active = true
            };

            var bicepsEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Flexii cu bara Z",
                Description = "",
                WorkoutId = bicepsWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var bicepsEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Flexii cu haltera",
                Description = "",
                WorkoutId = bicepsWorkout.Id,
                ActiveEx = true,
                Repetitions = 8
            };

            var bicepsEx3 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Flexii cu gantera la bara Scott",
                Description = "",
                WorkoutId = bicepsWorkout.Id,
                ActiveEx = true,
                Repetitions = 8
            };

            #endregion

            #region "Triceps"

            var tricepsWorkout = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Antrenament triceps",
                Description = "Grupe de muschi afectate: triceps, triceps brahial",
                Type = WorkoutType.Triceps,
                Active = true
            };

            var tricepsEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Extensii la scripete cu funia",
                Description = "",
                WorkoutId = tricepsWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var tricepsEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Extensii triceps cu gantera",
                Description = "",
                WorkoutId = tricepsWorkout.Id,
                ActiveEx = true,
                Repetitions = 8
            };

            var tricepsEx3 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Flotari la paralele",
                Description = "",
                WorkoutId = tricepsWorkout.Id,
                ActiveEx = true,
                Repetitions = 8
            };

            #endregion

            #region "Umeri"

            var shouldersWorkout = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Antrenament umeri",
                Description = "Grupe de muschi afectate: deltoid anterior, deltoid median, deltoid posterior",
                Type = WorkoutType.Shoulders,
                Active = true
            };

            var shouldersEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Fluturari din aplecat",
                Description = "",
                WorkoutId = shouldersWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var shouldersEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Presa cu gantere",
                Description = "",
                WorkoutId = shouldersWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var shouldersEx3 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Ridicari laterale-frontale alternate cu gantera",
                Description = "",
                WorkoutId = shouldersWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            #endregion

            #region "Abdomen"

            var absWorkout = new Workout
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Antrenament abdomene",
                Description = "Grupe de muschi afectate: drept abdominal, oblic extern, oblic intern, transvers",
                Type = WorkoutType.Abs,
                Active = true
            };

            var absEx1 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Crunch superior",
                Description = "",
                WorkoutId = absWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var absEx2 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Ridicari inferioare",
                Description = "",
                WorkoutId = absWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            var absEx3 = new WorkoutExercise
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Ridicari simultane",
                Description = "",
                WorkoutId = absWorkout.Id,
                ActiveEx = true,
                Repetitions = 10
            };

            #endregion

            context.Workouts.AddOrUpdate(p => p.Name, chestWorkout, backWorkout, legsWorkout, bicepsWorkout, tricepsWorkout, shouldersWorkout, absWorkout);
            context.WorkoutExercises.AddOrUpdate(p => p.Name, chestEx1, chestEx2, chestEx3, backEx1, backEx2, backEx3, legsEx1, legsEx2, legsEx3, bicepsEx1, bicepsEx2, bicepsEx3, tricepsEx1, tricepsEx2, tricepsEx3, shouldersEx1, shouldersEx2, shouldersEx3, absEx1, absEx2, absEx3);
        }
    }
}
