namespace NamelessInteractive.Insured.Web.Controllers.Api.PolicySection

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.PolicySection

type OccupationCategoryController() =
    inherit ApiControllerBase()
    let occupationCategoryQueries =
        {
            OccupationCategoryQueries.GetOccupationCategories = NamelessInteractive.Insured.Data.PolicySection.GetOccupationCategories
        }
    member this.Get() =
        occupationCategoryQueries.GetOccupationCategories()