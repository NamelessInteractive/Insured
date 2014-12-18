namespace NamelessInteractive.Insured.Web.Controllers.Mvc

open System.Web.Mvc

type HomeController() =
    inherit Controller()
    member this.Index() = this.View()
    member this.Home() = this.PartialView()