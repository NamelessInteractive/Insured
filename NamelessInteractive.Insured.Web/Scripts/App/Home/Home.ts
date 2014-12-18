module InsuredApp {
    export module Controllers {
        export class HomeController {
            static Name = "HomeController";
            static TemplateUrl = "/Organisation/Test";
            static Route: ng.route.IRoute = {
                controller : HomeController.Name,
                templateUrl : HomeController.TemplateUrl,
            };
            $scope: any;
            constructor($scope) {
                this.$scope = $scope;
                this.$scope.Organisation = ViewModels.Organisation.Organisation.Test();
            }
        }
    }
}

Application.controller('HomeController', function HomeController($scope) {
    return new InsuredApp.Controllers.HomeController($scope);
})