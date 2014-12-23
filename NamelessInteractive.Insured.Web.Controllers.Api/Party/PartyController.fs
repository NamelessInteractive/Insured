namespace NamelessInteractive.Insured.Web.Controllers.Api.Party

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Party
open NamelessInteractive.Insured.Domain.Party

type PartyController() =
    inherit ApiControllerBase()
    let partyQueries = 
        {
            PartyQueries.GetParties = NamelessInteractive.Insured.Data.Party.GetParties
            PartyQueries.GetPartyById = NamelessInteractive.Insured.Data.Party.GetPartyById
        }
    member this.Get() : Party seq =
        partyQueries.GetParties()
    member this.Get(id: int) =
        partyQueries.GetPartyById(id)