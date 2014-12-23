namespace NamelessInteractive.Insured.Web.Controllers.Api.Business

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Business

type LineOfBusinessController() =
    inherit ApiControllerBase()
    let lineOfBusinessQueries =
        {
            LineOfBusinessQueries.GetLinesOfBusiness = NamelessInteractive.Insured.Data.Business.GetLinesOfBusiness
        }
    member this.Get() =
        lineOfBusinessQueries.GetLinesOfBusiness()
