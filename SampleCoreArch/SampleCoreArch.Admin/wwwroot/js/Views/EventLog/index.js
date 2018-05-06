var model = null;
var EventLog = function (data) {
    var self = this;

    if (!data) {
        data = {};
    }

    self.Id = ko.observable(data.Id);
    self.Message = ko.observable(data.Message);
    self.EventId = ko.observable(data.EventId);
    self.LogLevel = ko.observable(data.LogLevel);
    self.IpAdress = ko.observable(data.IpAdress);
    self.HostName = ko.observable(data.HostName);
    self.CreatedTime = ko.observable(data.CreatedTime);

    self.availableCountries = ko.observableArray([
        { name: "Bungle", type: "Bear" },
        { name: "George", type: "Hippo" },
        { name: "Zippy", type: "Unknown" }
    ]);
    
    self.selectedCountry = ko.observable();
};


function RecordViewModel() {
    var url = "/EventLog/Index/?format=json";
    var self = this;
    self.items = ko.observableArray();
    self.selectedItem = ko.observable(new EventLog());
    
    var baseUri = '';

    self.create = function () {
        App.Get("/EventLog/Create/?format=json", null, null, function (response) {
            self.selectedItem(response.ResultObject);
        });

        $('#myModal').modal('show');
    }

    //self.create = function (formElement) {
    //    // If valid, post the serialized form data to the web api
    //    //$(formElement).validate();
    //    //if ($(formElement).valid()) {
    //    //    $.post(baseUri, $(formElement).serialize(), null, "json")
    //    //        .done(function (o) { self.items.push(o); });
    //    //}
    //}

    self.save = function (formElement) {
        $(formElement).validate();
        if ($(formElement).valid()) {
            console.log(ko.toJSON(self.selectedItem));
            App.Get(url, null, null, function (response) {
                self.items(response.ResultObject);
            });
            $('#myModal').modal('hide');
            //$.ajax({ type: "PUT", url: baseUri + '/' + self.selectedItem.Id, data: self.selectedItem });

            //$.post(baseUri, $(formElement).serialize(), null, "json").done(function (o) { self.items.push(o); });
        }

    }

    self.remove = function (record) {
        // First remove from the server, then from the UI
        $.ajax({ type: "DELETE", url: baseUri + '/' + record.Id }).done(function () { self.items.remove(record); });
    }

    self.detail = function (record) {
        self.selectedItem(new EventLog(record));
        $('#myModal').modal('show');
    }
    
    App.Get("/EventLog/Index/?format=json", null, null, function (response) {
        self.items(response.ResultObject);
        
    });
}

$(document).ready(function () {
    model = new RecordViewModel();
    ko.options.deferUpdates = true;
    ko.applyBindings(model);
});
