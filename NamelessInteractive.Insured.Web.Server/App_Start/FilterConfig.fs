module NamelessInteractive.Insured.Web.FilterConfig

open System.Web.Mvc

let RegisterGlobalFilters(filters: GlobalFilterCollection) =
    filters.Add(HandleErrorAttribute())

