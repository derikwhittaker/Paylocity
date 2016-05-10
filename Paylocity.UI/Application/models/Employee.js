var Employee = function() {
    var self = this;

    self.Name = ko.observable("");
    self.Dependants = ko.observableArray([]);
    self.BenefitCost = new BenefitCost();
};

var Dependant = function() {
    var self = this;

    self.Name = ko.observable("");
    self.BenefitCost = new BenefitCost();
};

var BenefitCost = function() {
    var self = this;
    
    self.AnnualCost = ko.observable(0);
    self.CycleCost = ko.observable(0);
    self.DiscountAmount = ko.observable(0);
    self.MonthlyCost = ko.observable(0);
};