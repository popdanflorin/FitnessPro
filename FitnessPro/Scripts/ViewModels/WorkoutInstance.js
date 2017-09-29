function WorkoutInstance() {
    var self = this;
    self.resultChart = null;
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
    self.Rounds = ko.observable();

    self.changeWorkout = function (data) {
        if (data === undefined)
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
        self.Rounds(data.Rounds);
        var url = '/WorkoutInstance/RefreshExercisesForDetails';
        $.ajax(url, {
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: { workoutInstanceId: self.Id() },
            success: function (data) {
                console.log(data);
                self.WorkoutInstanceExercises(data.Exercises);
                var plannedRepetitionList = [];
                var actualRepetitionList = [];
                var exerciseNameList2 = [];
                var len = self.WorkoutInstanceExercises().length;
                for (var i = 0, len; i < len; i++) {
                    plannedRepetitionList[i] = self.WorkoutInstanceExercises()[i].PlannedRepetitions;
                    actualRepetitionList[i] = self.WorkoutInstanceExercises()[i].ActualRepetitions;
                    exerciseNameList2[i] = self.WorkoutInstanceExercises()[i].ExerciseName;
                }
                plannedRepetitionList[len] = 0;
             
                var ctx = document.getElementById("ActualChart");
               
                if (self.resultChart != null)
                    self.resultChart.destroy();

                self.resultChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: exerciseNameList2,
                        datasets: [
                          {
                              data: plannedRepetitionList,
                              backgroundColor: ['#581845', '#581845', '#581845', '#581845', '#581845', '#581845', '#581845', '#581845', '#581845', '#581845'],
                             label: "Planned Repetitions",
                          },
                        {
                            data: actualRepetitionList,
                            backgroundColor: ['#C70039', '#C70039', '#C70039', '#C70039', '#C70039', '#C70039', '#C70039', '#C70039', '#C70039', '#C70039'],
                            label: "Actual Repetitions",
                    }
                        ]

                    },
                   
                   
                  
                    
                });
                
               
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
        self.Rounds(data.Rounds);
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
        self.Rounds(null);
        self.WorkoutName(null);
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
            Rounds: self.Rounds(),
            WorkoutName: self.WorkoutName(),
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
        self.Active(data.Active);
        self.Rounds(data.Rounds)
    };
    
    self.delete2 = function (data) {
        if (data === undefined)
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