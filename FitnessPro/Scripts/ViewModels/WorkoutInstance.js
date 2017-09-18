﻿function WorkoutInstance() {
    var self = this;
    self.Workouts = ko.observableArray();
    self.WorkoutInstances = ko.observableArray();
    self.Statuses = ko.observableArray();
    self.WorkoutInstanceExercises = ko.observableArray();
    self.Id = ko.observable();
    self.WorkoutId = ko.observable();
    self.Name = ko.observable();
    self.Date = ko.observable();
    self.Status = ko.observable();
    self.UserId = ko.observable();
    self.Active = ko.observable();
    self.WorkoutName = ko.observable();
   

    self.changeWorkout = function (data) {
        if (data == undefined)
            return;
        var workoutId = $('#WorkoutName').val();
        self.WorkoutId(workoutId);
        var url = '/WorkoutInstance/RefreshExercises';
        $.ajax(url, {
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: { workoutId: workoutId },
            success: function (data) {
                console.log(data);
                self.WorkoutInstanceExercises(data.Exercises);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    }

    self.details = function (data) {
        self.Id(data.Id);
        self.WorkoutId(data.WorkoutId);
        self.Name(data.Name);
        self.Date(data.Date);
        self.Status(data.Status);
        self.UserId(data.UserId);
        self.Active(data.Active);
        self.WorkoutName(data.WorkoutName);
        var url = '/WorkoutInstance/RefreshExercisesForDetails';
        $.ajax(url, {
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: { workoutInstanceId: self.Id() },
            success: function (data) {
                console.log(data);
                self.WorkoutInstanceExercises(data.Exercises);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };
    
    self.complete = function (data) {
        self.Id(data.Id);
        self.WorkoutId(data.WorkoutId);
        self.Name(data.Name);
        self.Date(data.Date);
        self.Status(1);
        self.UserId(data.UserId);
        self.Active(data.Active);
        self.WorkoutName(data.WorkoutName);
        var url = '/WorkoutInstance/RefreshExercisesForDetails';
        $.ajax(url, {
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: { workoutInstanceId: self.Id() },
            success: function (data) {
                console.log(data);
                self.WorkoutInstanceExercises(data.Exercises);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };

    self.add = function () {
        self.Id(null);
        self.WorkoutId(null);
        self.Date(null);
        self.Status(null);
        self.UserId(null);
        self.Active(null);
    };
    self.save = function () {
        var url = '/WorkoutInstance/SaveInstanceWithExercises';
        var wi = {
            Id: self.Id(),
            WorkoutId: self.WorkoutId(),
            Date: self.Date(),
            Status: self.Status(),
            UserId: self.UserId(),
            Active: self.Active(),
            Workout: null
        }
        var vIExercises = self.WorkoutInstanceExercises();
        var postData = JSON.stringify(
            {
                workoutInstance: wi,
                vIExercises: vIExercises
            })

        $.ajax(url, {
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            //data: ,
            data: postData,
            success: function (data) {
                console.log(data);
                self.refresh();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });

    };
    
    self.deleteWindow = function (data) {
        self.Id(data.Id);
        self.WorkoutId(data.WorkoutId);
        self.Name(data.Name);
        self.Date(data.Date);
        self.Status(data.Status);
        self.UserId(data.UserId);
        self.Active(data.Active)
    };
    
    self.delete2 = function (data) {
        if (data == undefined)
            return;
        var url = '/WorkoutInstance/Delete';
        var food = JSON.stringify({
            id: data.Id()
        });
        $.ajax(url, {
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: food,
            success: function (data) {
                console.log(data);
                self.refresh();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };
    self.refresh = function () {
        var url = '/WorkoutInstance/ListRefresh';
        $.ajax(url, {
            type: "get",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                self.Workouts(data.Workouts);
                self.WorkoutInstances(data.WorkoutInstances);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };
}