namespace NamelessInteractive.Insured.Web.Controllers.Mvc

open System.Web.Mvc

type OrganisationController() =
    inherit Controller()
    member this.Display() = this.PartialView()
    member this.Edit() = this.PartialView()