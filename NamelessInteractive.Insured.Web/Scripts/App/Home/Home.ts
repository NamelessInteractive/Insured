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
            constructor($scope, organisationService: InsuredApp.Services.Organisation.OrganisationService) {
                var that = this;
                this.$scope = $scope;
                organisationService.Get(100).$promise.then(function (data) {
                    that.$scope.Organisation = ViewModels.Organisation.Organisation.Parse(data);
                });
                //this.$scope.Organisation = ViewModels.Organisation.Organisation.Test();
            }
        }
    }
}

Application.controller('HomeController', function HomeController($scope, OrganisationService: InsuredApp.Services.Organisation.OrganisationService) {
    return new InsuredApp.Controllers.HomeController($scope, OrganisationService);
})