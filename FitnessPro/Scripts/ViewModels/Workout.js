function Workout() {
    var self = this;
    //Workout
    self.Workouts = ko.observableArray();
    self.Types = ko.observableArray();
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.Active = ko.observable();
    self.Type = ko.observable();
   
    //Workout Exercises
    self.Exercises = ko.observableArray();
    //self.ExId = ko.observable();
    self.ExName = ko.observable();
    self.ExDescription = ko.observable();
    self.ExWorkoutId = ko.observable();
    self.Repetitions = ko.observable();
    self.ActiveEx = ko.observable();

    //Log
    self.Logs = ko.observableArray();
    self.LogWorkoutId = ko.observable();
    self.LogId = ko.observable();
    self.Entity = ko.observable();
    self.PrimaryEntityId = ko.observable();
    self.SecondaryEntityId = ko.observable();
    self.LogDate = ko.observable();
    self.Operation = ko.observable();
    self.Property = ko.observable();
    self.OldValue = ko.observable();
    self.NewValue = ko.observable();


    //Functions for Workout
    self.details = function (data) {
        self.Id(data.Id);
        self.Name(data.Name);
        self.Description(data.Description);
        self.Active(data.Active);
        self.Type(data.Type);
    };

    self.add = function () {
        self.Id(null);
        self.Name(null);
        self.Description(null);
        self.Active(null);
        self.Type(null);

       /* self.LogId(null);
        self.Entity(null);
        self.PrimaryEntityId(null);
        self.SecondaryEntityId(null);
        self.LogDate(null);
        self.Operation(null);
        self.Property(null);
        self.OldValue(null);
        self.NewValue(null);*/

    };
    
    self.save = function () {
        var url = '/Workout/Save';
        var workout = JSON.stringify({
            Id: self.Id(),
            Name: self.Name(),
            Description: self.Description(),
            Active: self.Active(),
            Type: self.Type(),
         
            
        });
        $.ajax(url, {
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: workout,
            success: function (data) {
                console.log(data);
                
                self.refresh();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(data);
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };
   
    self.delete = function (data) {
        var url = '/Workout/Delete';
        var workout = JSON.stringify({
            id: data.Id
        });
        $.ajax(url, {
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: workout,
            success: function (data) {
                console.log(data);
                alert(data);
                self.refresh();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };

    self.refresh = function () {
        var url = '/Workout/ListRefresh';
        $.ajax(url, {
            type: "get",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                self.Workouts(data.Workouts);
                self.Types(data.WorkoutTypes);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };

    //Functions for Workout Exercises
    self.addEx = function (data) {
        self.Id(null);
        //self.ExId(null);
        self.ExName(null);
        self.ExDescription(null);
        self.Repetitions(null);
        self.ActiveEx(null);
    }

    self.getExDetails = function (data) {
        self.Id(data.Id);
        //self.ExId(data.ExId);
        self.ExName(data.Name);
        self.ExDescription(data.Description);
        self.Repetitions(data.Repetitions);
        self.ActiveEx(data.ActiveEx);
    }

    self.getExercises = function (data) {
        var url = '/Workout/GetEx';
        var workoutId = data.Id;
        $.ajax(url, {
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: { workoutId: data.Id },
            success: function (data) {
                console.log(data);
                
                self.Exercises(data.Exercises);
                self.ExWorkoutId(workoutId);
                
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    }

    //save exercise
    self.saveEx = function () {
        var url = '/Workout/SaveEx';
        
        var exercise = JSON.stringify({
            Id: self.Id(),
            workoutId: self.ExWorkoutId(),
            Name: self.ExName(),
            Description: self.ExDescription(),
            Repetitions: self.Repetitions(),
            ActiveEx: self.ActiveEx(),
        });
        $.ajax(url, {
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: exercise,
            success: function (data) {
                console.log(data);
                $('#workoutNewEx').modal('hide');
                self.refreshEx(self.ExWorkoutId);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };
    self.deleteEx = function (data) {
        var workoutId = data.WorkoutId;
        var url = '/Workout/DeleteEx';
        var exercise = JSON.stringify({
            id: data.Id
        });
        $.ajax(url, {
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: exercise,
            success: function (data) {
                console.log(data);
                self.refreshEx(workoutId);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };

    self.refreshEx = function (id) {
        var url = '/Workout/GetEx';
        $.ajax(url, {
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: { workoutId: id },
            success: function (data) {
                console.log(data);
                self.Exercises(data.Exercises);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };
    self.hideNewExercise = function ()
    {
        $('#workoutNewEx').modal('hide');
    }

    self.holdForDeleteEx = function (data) {
        self.Id(data.Id);
        //self.ExId(data.ExId);
        self.Name(data.Name);
        self.Description(data.Description);
        self.Type(data.Type);
        self.Exercises(data.Exercises);
        
    }
    self.getEntityDetails = function (data) {
        var url = '/Workout/GetEntityOp';
        var workoutId = data.Id;
        $.ajax(url, {
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: { workoutId: data.Id },
            success: function (data) {
                console.log(data);
                self.Logs(data.Operations);
                //self.LogWorkoutId(workoutId);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    }
}