namespace NamelessInteractive.Insured.Web.Controllers.Api.Party

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Party

type CreditRatingController() =
    inherit ApiControllerBase()
    let creditRatingQueries = 
        {
            CreditRatingQueries.GetCreditRatings = NamelessInteractive.Insured.Data.Party.GetCreditRatings
        }
    member this.Get() =
        creditRatingQueries.GetCreditRatings()