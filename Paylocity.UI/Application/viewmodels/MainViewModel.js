var MainViewModel = function() {
    var self = this;

    self.employeeVms = ko.observableArray([]);

    self.addEmployee = function() {
        self.employeeVms.push(new EmployeeViewModel());
    };
};

var EmployeeViewModel = function() {
    var self = this;

    self.employee = new Employee();
    self.salary = ko.observable(2000);
    self.totalDeductions = ko.observable(0);
    self.postDeductionsSalary = ko.observable(0);

    self.addDependant = function () {
        var dependant = new Dependant();
        self.employee.Dependants.push(dependant);
    };

    self.removeDependant = function(dependant) {
        self.employee.Dependants.remove(dependant);

        self.recalculateDeductions();
    }

    self.recalculateDeductions = function () {
        var callback = function (results) {
            var costs = results.BenefitCost;
            self.totalDeductions(costs.CycleCost);
            self.postDeductionsSalary(self.salary() - costs.CycleCost);

        };
        DeductionsProvider.MemberDeductions(self.employee, callback);
    };

};