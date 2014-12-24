namespace NamelessInteractive.Insured.Web.Controllers.Api.Broker

open NamelessInteractive.Insured.Contracts.DataAccess.Broker
open NamelessInteractive.Insured.Web.Controllers.Api

type BrokerController() =
    inherit ApiControllerBase()
    let queries = 
        {
            BrokerQueries.GetBrokers = NamelessInteractive.Insured.Data.Broker.GetBrokers
        }
    member this.Get() =
        queries.GetBrokers()

