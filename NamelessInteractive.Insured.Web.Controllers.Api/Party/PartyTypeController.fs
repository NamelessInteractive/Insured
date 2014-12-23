namespace NamelessInteractive.Insured.Web.Controllers.Api.Party

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Party
open NamelessInteractive.Insured.Domain.Party

type PartyTypeController() =
    inherit ApiControllerBase()
    let partyTypeQueries = 
        {
            GetPartyTypes = NamelessInteractive.Insured.Data.Party.GetPartyTypes
        }
    member this.Get() : PartyType seq =
        partyTypeQueries.GetPartyTypes()
