function Diagram() {
  
    var self = this;
   
    self.datePercentageList = ko.observableArray();
    self.refreshDatePercentage = function () {
        var url = '/Results/DatePercentageListRefresh';
        $.ajax(url, {
            type: "get",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                self.datePercentageList(data.datePercentageList);
                var percentageList = [];
                var dateList = [];
                var len = self.datePercentageList().length;
                for (var i = 0, len; i < len; i++) {
                    percentageList[i] = self.datePercentageList()[i].Percentage;
                    dateList[i] = self.datePercentageList()[i].Date;
                }
                
                var ctx = document.getElementById("resultChart");
                var resultChart = new Chart(ctx, {
                    type: 'line',
                    data: {
                        labels: dateList,
                        datasets: [
                          {
                              data: percentageList,
                              
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
