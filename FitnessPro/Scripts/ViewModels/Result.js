function Result() {
    var self = this;
    self.CompletedWorkoutInstances = ko.observableArray();
    self.Statuses = ko.observableArray();
    self.Id = ko.observable();
    self.WorkoutId = ko.observable();
    self.Date = ko.observable();
    self.Status = ko.observable();
    self.UserId = ko.observable();
    self.Active = ko.observable();
    self.WorkoutName = ko.observable();
    self.Rounds = ko.observable();
    self.Percentage = ko.observable();
    self.Points = ko.observable();
    self.TotalPoints = ko.observable();
    self.TotalPercentage = ko.observable();
    self.UserName = ko.observable();

    self.refresh = function () {
        var url = '/Results/ListRefresh';
        $.ajax(url, {
            type: "get",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                self.CompletedWorkoutInstances(data.CompletedWorkoutInstances);
                self.TotalPercentage(data.TotalPercentage);
                self.TotalPoints(data.TotalPoints);
                self.UserName(data.UserName);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    }
}