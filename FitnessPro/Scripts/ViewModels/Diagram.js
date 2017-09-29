function Diagram() {

    var self = this;

    self.datePercentageList = ko.observableArray();
    self.workoutPercentageList = ko.observableArray();
    self.refreshDatePercentage = function () {
        var url = '/Results/DatePercentageListRefresh';
        $.ajax(url, {
            type: "get",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                self.datePercentageList(data.datePercentageList);
                self.workoutPercentageList(data.workoutPercentageList);
                var percentageList = [];
                var dateList = [];
                var len = self.datePercentageList().length;
                for (var i = 0, len; i < len; i++) {
                    percentageList[i] = self.datePercentageList()[i].Percentage;
                    dateList[i] = moment(self.datePercentageList()[i].Date).format("YYYY-MM-DD")
                }
                percentageList[len] = 0.0;
                var ctx = document.getElementById("resultChart");
                var resultChart = new Chart(ctx, {
                    type: 'line',
                    data: {
                        labels: dateList,
                        datasets: [
                          {
                              data: percentageList,
                              label: "Average Percentage / Day",
                          }
                        ]
                    }
                });
                var percentageList2 = [];
                var workoutList2 = [];
                var len2 = self.workoutPercentageList().length;
                for (var i = 0, len2; i < len2; i++) {
                    percentageList2[i] = self.workoutPercentageList()[i].Percentage;
                    workoutList2[i] = self.workoutPercentageList()[i].WorkoutName;
                }

                var ctx = document.getElementById("resultWorkoutChart");
                var resultChart = new Chart(ctx, {
                    type: 'polarArea',
                    data: {
                        labels: workoutList2,
                        datasets: [
                          {
                              data: percentageList2,
                              label: "Average Percentage / Workout",
                              backgroundColor: ['rgba(88, 24, 69, 0.7)', 'rgba(144, 12, 63, 0.7)', 'rgba(255, 87, 51, 0.7)', 'rgba(255, 195, 0, 0.7)','rgba(218, 247, 166, 0.7)', 'rgba(97, 191, 136, 0.5)', '#900C3F', '#C70039', '#FF5733', '#FFC300', '#DAF7A6', '#581845', '#581845', '#581845', '#581845'],
                          }
                        ]
                    }
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });

    }
}