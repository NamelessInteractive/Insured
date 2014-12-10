/// <reference path="../../typings/angularjs/angular.d.ts" />
module InsuredApp {
    export class Core {
        static ApplicationName = "InsuredApp";
        static Dependencies = ['ngResource', 'ngRoute'];
        static ConfigureApplication($routeProvider) {
            Router.ConfigureRoutes($routeProvider);
        }

        static RunApplication() {
        }
    }

}


var Application =
    angular.module(
        InsuredApp.Core.ApplicationName,
        InsuredApp.Core.Dependencies
        )
        .config(InsuredApp.Core.ConfigureApplication)
        .run(InsuredApp.Core.RunApplication);

angular.element(document).ready(function () {
    angular.bootstrap(document, [InsuredApp.Core.ApplicationName]);
});