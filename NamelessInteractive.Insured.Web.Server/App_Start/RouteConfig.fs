module NamelessInteractive.Insured.Web.RouteConfig

open System.Web.Mvc
open System.Web.Routing

type SimpleMvcRoute = 
    {
        Controller: string
        Action: string
        Id: UrlParameter
    }

let private RegisterRouteCore (routes: RouteCollection) name template (defaults:obj) =
    routes.MapRoute(name,template,defaults) |> ignore

let RegisterRoutes (routes:RouteCollection) =
    let RegisterRoute = RegisterRouteCore routes
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
    RegisterRoute 
        "Default"
        "{controller}/{action}/{id}"
        {
            Controller = "Home"
            Action = "Index"
            Id = UrlParameter.Optional
        }
    