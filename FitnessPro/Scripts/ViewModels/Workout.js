function Workout() {
    var self = this;
    self.Workouts = ko.observableArray();
    self.Types = ko.observableArray();
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.Type = ko.observable();

    self.details = function (data) {
        self.Id(data.Id);
        self.Name(data.Name);
        self.Description(data.Description);
        self.Type(data.Type);
    };
    self.add = function () {
        self.Id(null);
        self.Name(null);
        self.Description(null);
        self.Type(null);
    };
    self.save = function () {
        var url = '/Workout/Save';
        var workout = JSON.stringify({
            Id: self.Id(),
            Name: self.Name(),
            Description: self.Description(),
            Type: self.Type()
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
}