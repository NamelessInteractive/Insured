module InsuredApp {
    export module Controllers {
        export class HomeController {
            static Name = "HomeController";
            static TemplateUrl = "/Individual/Test";
            static Route: ng.route.IRoute = {
                controller : HomeController.Name,
                templateUrl : HomeController.TemplateUrl,
            };
            $scope: any;
            constructor($scope,IndividualService: InsuredApp.Services.Individual.IndividualService) {
                var that = this;
                this.$scope = $scope;
                this.$scope.Individual = IndividualService.Get(100);
            }
        }
    }
}

Application.controller('HomeController', function HomeController($scope, IndividualService: InsuredApp.Services.Individual.IndividualService) {
    return new InsuredApp.Controllers.HomeController($scope,IndividualService);
})