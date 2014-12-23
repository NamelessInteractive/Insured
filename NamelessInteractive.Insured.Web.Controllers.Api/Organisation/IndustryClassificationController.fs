namespace NamelessInteractive.Insured.Web.Controllers.Api.Organisation

open System.Web.Http
open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Organisation
open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Organisation

type IndustryClassificationController() =
    inherit ApiControllerBase()
    let industryClassificationQueries = 
        {
            IndustryClassificationQueries.GetIndustryClassifications = NamelessInteractive.Insured.Data.Organisation.GetIndustryClassifications
        }
    member this.Get(): IndustryClassification seq =
        industryClassificationQueries.GetIndustryClassifications()