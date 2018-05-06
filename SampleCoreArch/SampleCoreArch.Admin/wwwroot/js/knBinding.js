var model = new AppViewModel();

function EventLogModel(data) {
    var self = this;
    self.Id = ko.observable(data.Id);
    self.Message = ko.observable(data.Message);
    self.EventId = ko.observable(data.EventId);
    self.LogLevel = ko.observable(data.LogLevel);
    self.IpAdress = ko.observable(data.IpAdress);
    self.HostName = ko.observable(data.HostName);
    self.CreatedTime = ko.observable(data.CreatedTime);

    self.Save = function () {
        alert("save");
        var validator = $("form").validate();
        if ($("form").valid()) {
            model.EventLogList();
        } else {
            validator.focusInvalid();
        }

        model.Result.ResultObject = ko.toJSON(model.EventLogViewModel);
        console.log(model.Result);
    }

    self.Delete = function () {
        alert("delete");
        model.EventLogList();
    }

    self.Edit = function () {
        model.EventLogEdit(self.Id());
        $('#myModal').modal('show');
    }
}

function AppViewModel() {
    var self = this;
    self.EventLogViewModel = ko.observable();
    self.EventLogViewModel.List = ko.observableArray();

    self.EventLogList = function () {

        var url = "/EventLog/Index/?format=json";
        App.Get(url, null, function (response) {

            $.each(response.ResultObject, function (index, value) {
                self.EventLogViewModel.List.push(new EventLogModel(value));
            });

        });

    }
    self.EventLogNew = function () {
        self.EventLogViewModel(new EventLogModel({}));
        alert("EventLogAdd");
    }
    self.EventLogEdit = function (Id, callback) {
        alert("EventLogEdit" + Id);

        var modelProject = new EventLogModel({ Id: 1, Message: "test" });
        self.EventLogViewModel(modelProject);

        //var url = "/Project/Detail/" + Id;

        //App.Post(url,
        //    null,
        //    function (response) {
        //        var modelProject = new ProjectModel(response.ResultObject);
        //        self.ProjectViewModel(modelProject);
        //        model.Result.Status(false);
        //        callback();
        //    });
    }






    self.Result = {};
    self.Result.ResultStatus = ko.observable(false);
    self.Result.ResultObject = ko.observable();
    self.Result.ResultCode = ko.observable();
    self.Result.ResultCss = ko.observable();
    self.Result.ResultMessage = ko.observable("İşleminiz başarısız oldu ! Lütfen daha sonra tekrar deneyiniz.");
    self.Result.ResultClose = function () {
        self.Result.ResultStatus(false);
    }

    self.Result.ResultCss = ko.pureComputed(function () {
        return self.Result.ResultCode() !== 200 ? "alert alert-danger alert-dismissable" : "alert alert-success alert-dismissable";
    }, this);

}

ko.options.deferUpdates = true;


ko.applyBindings(model);