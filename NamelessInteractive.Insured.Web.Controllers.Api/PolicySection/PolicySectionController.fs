namespace NamelessInteractive.Insured.Web.Controllers.Api.PolicySection

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.PolicySection

type PolicySectionController() =
    inherit ApiControllerBase()
    let policySectionQueries =
        {
            GetPolicySections = NamelessInteractive.Insured.Data.PolicySection.GetPolicySections
            GetPolicySectionById = NamelessInteractive.Insured.Data.PolicySection.GetPolicySectionById
        }
    member this.Get() =
        policySectionQueries.GetPolicySections()
    member this.Get id =
        policySectionQueries.GetPolicySectionById id