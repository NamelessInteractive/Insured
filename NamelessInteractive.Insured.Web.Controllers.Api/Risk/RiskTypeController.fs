namespace NamelessInteractive.Insured.Web.Controllers.Api.Risk

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Risk

type RiskTypeController() =
    inherit ApiControllerBase()
    let riskTypeQueries = 
        {
            RiskTypeQueries.GetRiskTypes = NamelessInteractive.Insured.Data.Risk.GetRiskTypes
        }
    member this.Get() =
        riskTypeQueries.GetRiskTypes()

