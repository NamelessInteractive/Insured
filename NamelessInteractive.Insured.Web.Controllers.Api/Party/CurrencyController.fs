namespace NamelessInteractive.Insured.Web.Controllers.Api.Party

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Party

type CurrencyController() =
    inherit ApiControllerBase()
    let currencyQueries = 
        {
            CurrencyQueries.GetCurrencies = NamelessInteractive.Insured.Data.Party.GetCurrencies
        }
    member this.Get() =
        currencyQueries.GetCurrencies()