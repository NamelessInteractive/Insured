namespace NamelessInteractive.Insured.Web.Controllers.Api.Organisation

open System.Web.Http
open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Organisation

type IndustryController() =
    inherit ApiController()
    member this.Get() : Industry seq =  
        [
            {
                Industry.Id = Shared.Identifier(1)
                Code = "INDTYPE1"
                Description = "Industry Type 1"
            }
            {
                Industry.Id = Shared.Identifier(2)
                Code = "INDTYPE2"
                Description = "Industry Type 2"
            }
        ] |> Seq.ofList