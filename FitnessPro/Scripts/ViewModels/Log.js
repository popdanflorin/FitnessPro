function Log() {
    var self = this;
    self.Logs = ko.observableArray();
    self.LogId = ko.observable();
    self.Entity = ko.observable();
    self.PrimaryEntityId = ko.observable();
    self.SecondaryEntityId = ko.observable();
    self.LogDate = ko.observable();
    self.Type = ko.observable();
    self.Property = ko.observable();
    self.OldValue = ko.observable();
    self.NewValue = ko.observable();
    
    self.refresh = function () {
        var url = '/Logs/ListRefresh';
        $.ajax(url, {
            type: "get",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                self.Logs(data.Logs);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ': ' + errorThrown);
            }
        });
    }
}