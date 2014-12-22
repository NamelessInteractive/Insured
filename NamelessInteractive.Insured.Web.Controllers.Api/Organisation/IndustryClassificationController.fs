namespace NamelessInteractive.Insured.Web.Controllers.Api.Organisation

open System.Web.Http
open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Organisation

type IndustryClassificationController() =
    inherit ApiController()
    member this.Get(): IndustryClassification seq =
        [
            {
                IndustryClassification.Id = Shared.Identifier(1)
                Code = "INDCLASS1"
                Description = "Industry Classification 1"
                Category = "Category 1"
                IndustryCode = "Industry Code"
            }
            {
                IndustryClassification.Id = Shared.Identifier(2)
                Code = "INDCLASS2"
                Description = "Industry Classification 2"
                Category = "Category 2"
                IndustryCode = "Industry Code"
            }
        ] |> Seq.ofList
        

