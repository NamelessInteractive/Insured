module NamelessInteractive.Insured.Web.BundleConfig

open System.Web.Optimization
open System

let private GetAppScripts() =
    let basePath = System.Web.HttpRuntime.AppDomainAppPath
    let scriptsPath = System.IO.Path.Combine(basePath, "Scripts","App")
    let files = System.IO.Directory.GetFiles(scriptsPath, "*.js", IO.SearchOption.AllDirectories)
    files |> Array.map (fun path -> path.Replace(scriptsPath,"~/Scripts/App/").Replace("\\","/"))

let RegisterBundles(bundles: BundleCollection) :unit =
    let AddBundle = bundles.Add
    ScriptBundle("~/bundles/jquery").Include([|"~/Scripts/lib/jquery-{version}.js"|])
    |> AddBundle

    ScriptBundle("~/bundles/modernizr").Include([|"~/Scripts/lib/modernizr-*"|])
    |> AddBundle

    ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/lib/bootstrap.js", "~/Scripts/lib/respond.js")
    |> AddBundle

    ScriptBundle("~/bundles/angularjs").Include("~/Scripts/lib/angular.js", "~/Scripts/lib/angular-resource.js", "~/Scripts/lib/angular-route.js")
    |> AddBundle

    ScriptBundle("~/bundles/app").Include(GetAppScripts())
    |> AddBundle

    StyleBundle("~/Content/css").Include([|"~/Content/bootstrap.css"|])
    |> AddBundle

    StyleBundle("~/Content/AppCss").Include("~/Content/App/AngularRules.css", "~/Content/App/site.css")
    |> AddBundle