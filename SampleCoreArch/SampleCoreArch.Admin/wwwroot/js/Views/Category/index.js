var model = null;

function ProductsViewModel() {
    var url = "/Category/Index/?format=json";
    var self = this;
    self.items = ko.observableArray();
    self.selectedItem = ko.observable({});

    var baseUri = '';

    self.create = function () {
        Common.Get("/Category/Create/?format=json", null, function (response) {
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
            Common.Get(url, null, function (response) {
                self.items(response.ResultObject);
            });
            $('#myModal').modal('hide');
            //$.ajax({ type: "PUT", url: baseUri + '/' + self.selectedItem.Id, data: self.selectedItem });

            //$.post(baseUri, $(formElement).serialize(), null, "json").done(function (o) { self.items.push(o); });
        }

    }

    self.remove = function (product) {
        // First remove from the server, then from the UI
        $.ajax({ type: "DELETE", url: baseUri + '/' + product.Id }).done(function () { self.items.remove(product); });
    }

    self.detail = function (product) {
        self.selectedItem(product);
        $('#myModal').modal('show');
    }
    
    Common.Get(url, null, function (response) {
        self.items(response.ResultObject);
    });
}

$(document).ready(function () {
    model = new ProductsViewModel();
    ko.options.deferUpdates = true;
    ko.applyBindings(model);
});
