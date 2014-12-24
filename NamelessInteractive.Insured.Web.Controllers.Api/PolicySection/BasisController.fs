namespace NamelessInteractive.Insured.Web.Controllers.Api.PolicySection

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.PolicySection

type BasisController() =
    inherit ApiControllerBase()
    let basisQueries = 
        {
            BasisQueries.GetBasises = NamelessInteractive.Insured.Data.PolicySection.GetBasises
        }
    member this.Get() =
        basisQueries.GetBasises()