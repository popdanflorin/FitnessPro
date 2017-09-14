function WorkoutInstance() {
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

    self.changeWorkout = function (data) {
        if (data == undefined)
            return;
        var workoutId = $('#WorkoutName').val();
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
    };
    self.add = function () {
        self.Id(null);
        self.WorkoutId(null);
        self.Date(null);
        self.Status(null);
        self.UserId(null);
    };
    self.save = function () {
        var url = '/WorkoutInstance/SaveInstanceWithExercises';
        var workoutInstance = JSON.stringify({
            Id: self.Id(),
            WorkoutId: self.WorkoutId(),
            Date: self.Date(),
            Status: self.Status(),
            UserId: self.UserId(),
        });
        var WorkoutInstanceExercises = JSON.stringify({
            WorkoutInstanceExercises: self.WorkoutInstanceExercises
        });
        /*var postData = {
            workoutInstance: workoutInstance,
            WorkoutInstanceExercises: WorkoutInstanceExercises
        };*/
        $.ajax(url, {
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            //data: JSON.stringify(postData),
            data: {workoutInstance,WorkoutInstanceExercises },
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

            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    };
}