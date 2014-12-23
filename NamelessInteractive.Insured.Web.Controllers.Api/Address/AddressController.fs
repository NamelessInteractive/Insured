namespace NamelessInteractive.Insured.Web.Controllers.Api.Address

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Address

type AddressController() =
    inherit ApiControllerBase()
    let addressQueries = 
        {
            AddressQueries.GetAddresses = NamelessInteractive.Insured.Data.Address.GetAddresses
            GetAddressById = NamelessInteractive.Insured.Data.Address.GetAddressById
        }
    member this.Get() = 
        addressQueries.GetAddresses()
    member this.Get(id: int) =
        addressQueries.GetAddressById id