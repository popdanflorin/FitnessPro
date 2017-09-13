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


    self.details = function (data) {
        self.Id(data.Id);
        self.WorkoutId(data.WorkoutId);
        self.Name(data.Name);
        self.Date(data.Date);
        self.Status(data.Status);
        self.UserId(data.UserId);
    };
    self.add = function () {
        self.Id(null);
        self.WorkoutId(null);
        self.Date(null);
        self.Status(null);
        self.UserId(null);
    };
    self.save = function () {
        var url = '/WorkoutInstance/Save';
        var workoutInstance = JSON.stringify({
            Id: self.Id(),
            WorkoutId: self.WorkoutId(),
            Date: self.Date(),
            Status: self.Status()
        });
        $.ajax(url, {
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: workoutInstance,
            success: function (data) {
                console.log(data);
                self.refresh();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };
    self.delete = function (data) {
        var url = '/Workout/Delete';
        var food = JSON.stringify({
            id: data.Id
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
                self.WorkoutExercises(data.WorkoutExercises);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };
}