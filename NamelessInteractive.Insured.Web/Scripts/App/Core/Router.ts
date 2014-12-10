module InsuredApp {
    export class Router {
        static ConfigureRoutes($routeProvider: ng.route.IRouteProvider) {
            $routeProvider.when('/', Controllers.HomeController.Route);
        }
    }
} 