namespace NamelessInteractive.Insured.Web.Controllers.Api.Party

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Party

type LanguageController() =
    inherit ApiControllerBase()
    let languageQueries = 
        {
            LanguageQueries.GetLanguages = NamelessInteractive.Insured.Data.Party.GetLanguages
        }
    member this.Get() =
        languageQueries.GetLanguages()
