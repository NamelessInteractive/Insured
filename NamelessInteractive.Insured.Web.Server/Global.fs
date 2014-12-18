namespace NamelessInteractive.Insured.Web

open System.Web.Mvc
open System.Web.Http
open System.Web.Routing
open System.Web.Optimization

type InsuredApplication() =
    inherit System.Web.HttpApplication()
    member this.Application_Start() : unit =
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(System.Action<HttpConfiguration>(WebApiConfig.Register))
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)