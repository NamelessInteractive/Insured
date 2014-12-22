namespace NamelessInteractive.Insured.Web.Controllers.Api.Organisation

open System.Web.Http
open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Organisation

type OrganisationTypeController() = 
    inherit ApiController()
    member this.Get() : OrganisationType seq =
        [
            { 
                OrganisationType.Id = Shared.Identifier(1)
                OrganisationType.Code = "ORGTYPE1"
                OrganisationType.Description = "Organisation Type 1"
            } 
            { 
                OrganisationType.Id = Shared.Identifier(2)
                OrganisationType.Code = "ORGTYPE2"
                OrganisationType.Description = "Organisation Type 2"
            } 
        ] |> Seq.ofList