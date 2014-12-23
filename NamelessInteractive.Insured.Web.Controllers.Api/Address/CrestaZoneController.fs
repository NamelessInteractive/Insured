namespace NamelessInteractive.Insured.Web.Controllers.Api.Address

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Domain.Address
open NamelessInteractive.Insured.Contracts.DataAccess.Address

type CrestaZoneController() =
    inherit ApiControllerBase()
    let crestaZoneQueries : CrestaZoneQueries =
        { 
            GetCrestaZones = NamelessInteractive.Insured.Data.Address.GetCrestaZones
        }
    member this.Get() : CrestaZone seq = 
        crestaZoneQueries.GetCrestaZones()