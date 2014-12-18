namespace NamelessInteractive.Insured.Web.Controllers.Mvc

open System.Web.Mvc

type AddressController() = 
    inherit Controller()
    member this.Index() =
        this.PartialView()
