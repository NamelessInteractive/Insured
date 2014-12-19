module NamelessInteractive.Insured.Web.WebApiConfig

open System.Web.Http
open NamelessInteractive.Insured.Infrastructure.Serializers
open Newtonsoft.Json.Serialization

type SimpleHttpRoute =
    {
        Controller: string
        Id: RouteParameter
    }

let private RegisterRouteCore (config: HttpConfiguration) name routeTemplate (defaults: obj) =
    config.Routes.MapHttpRoute(name, routeTemplate, defaults) |> ignore

let private RegisterConverters(config:HttpConfiguration) =
    config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- DefaultContractResolver()
    config.Formatters.Remove(config.Formatters.XmlFormatter) |> ignore
    config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(OptionConverter())
    config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(SingleCaseDUConverter())

let Register(config: HttpConfiguration) =
    RegisterConverters(config)
    let RegisterRoute = RegisterRouteCore config
    config.MapHttpAttributeRoutes()
    RegisterRoute 
        "DefaultApi"
        "api/{controller}/{id}"
        { Controller = "{controller}"; Id = RouteParameter.Optional }