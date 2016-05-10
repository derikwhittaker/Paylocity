var App = function() {
    var self = this;


    self.init = function() {
        var root = $("#paylocity-app").get(0);
        var mainVm = new MainViewModel();
        ko.applyBindings(mainVm, root);
    };
};



(function () {
    new App().init();
})();