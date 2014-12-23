namespace NamelessInteractive.Insured.Web.Controllers.Api.Address

open NamelessInteractive.Insured.Domain.Address
open NamelessInteractive.Insured.Contracts.DataAccess.Address
open NamelessInteractive.Insured.Web.Controllers.Api

type CountryController() =
    inherit ApiControllerBase()
    let countryQueries : CountryQueries =
        {
            GetCountries = NamelessInteractive.Insured.Data.Address.GetCountries
        }
    member this.Get() : Country seq =
        countryQueries.GetCountries()
        

