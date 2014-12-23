namespace NamelessInteractive.Insured.Web.Controllers.Api.Organisation

open System.Web.Http
open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Organisation
open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Organisation

type IndustryController() =
    inherit ApiControllerBase()
    let industryQueries = 
        {
            IndustryQueries.GetIndustries = NamelessInteractive.Insured.Data.Organisation.GetIndustries
        }
    member this.Get() : Industry seq =  
        industryQueries.GetIndustries()