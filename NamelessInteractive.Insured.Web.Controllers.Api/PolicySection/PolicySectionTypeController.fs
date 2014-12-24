namespace NamelessInteractive.Insured.Web.Controllers.Api.PolicySection

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.PolicySection

type PolicySectionTypeController() =
    inherit ApiControllerBase()
    let policySectionTypeQueries = 
        {
            PolicySectionTypeQueries.GetPolicySectionTypes = NamelessInteractive.Insured.Data.PolicySection.GetPolicySectionTypes
        }
    member this.Get() =
        policySectionTypeQueries.GetPolicySectionTypes()