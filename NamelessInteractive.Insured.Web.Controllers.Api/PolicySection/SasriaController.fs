namespace NamelessInteractive.Insured.Web.Controllers.Api.PolicySection

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.PolicySection

type SasriaController() =
    inherit ApiControllerBase()
    let sasriaQueries = 
        {
            SasriaQueries.GetSasrias = NamelessInteractive.Insured.Data.PolicySection.GetSasrias
        }
    member this.Get() =
        sasriaQueries.GetSasrias()