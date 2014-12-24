namespace NamelessInteractive.Insured.Web.Controllers.Api.Broker

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Broker

type BrokerCategoryController() =
    inherit ApiControllerBase()
    let queries = 
        {
            BrokerCategoryQueries.GetBrokerCategories = NamelessInteractive.Insured.Data.Broker.GetBrokerCategories
        }
    member this.Get() =
        queries.GetBrokerCategories()