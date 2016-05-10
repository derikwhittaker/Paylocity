var DeductionsProvider = {
    
    MemberDeductions: function(employee, callback) {
        callback = callback || function (r) { };

        var url = "http://localhost:49479/api/benefits/Costs";
        var model = {
            Employee: {
                Member: {
                    Name: employee.Name,
                    IsEmployee: true
                },
                Dependants: []
            }
        };

        ko.utils.arrayForEach(employee.Dependants(), function(dependant) {
            model.Employee.Dependants.push({ Name: dependant.Name() });
        });

        $.ajax({
            type: "Post",
            url: url,
            crossDomain: true,
            data: model,
            success: function (results) {
                callback(results);
            }
        });
    }
};