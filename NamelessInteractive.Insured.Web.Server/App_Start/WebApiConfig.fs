module NamelessInteractive.Insured.Web.WebApiConfig

open System.Web.Http

type SimpleHttpRoute =
    {
        Controller: string
        Id: RouteParameter
    }

let private RegisterRouteCore (config: HttpConfiguration) name routeTemplate (defaults: obj) =
    config.Routes.MapHttpRoute(name, routeTemplate, defaults) |> ignore



let Register(config: HttpConfiguration) =
    let RegisterRoute = RegisterRouteCore config
    config.MapHttpAttributeRoutes()
    RegisterRoute 
        "DefaultApi"
        "api/{controller}/{id}"
        { Controller = "{controller}"; Id = RouteParameter.Optional }