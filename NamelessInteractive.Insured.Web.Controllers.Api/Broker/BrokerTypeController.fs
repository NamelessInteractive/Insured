namespace NamelessInteractive.Insured.Web.Controllers.Api.Broker

open NamelessInteractive.Insured.Contracts.DataAccess.Broker
open NamelessInteractive.Insured.Web.Controllers.Api

type BrokerTypeController() =
    inherit ApiControllerBase()
    let queries = 
        {
            BrokerTypeQueries.GetBrokerTypes = NamelessInteractive.Insured.Data.Broker.GetBrokerTypes
        }
    member this.Get() = 
        queries.GetBrokerTypes()

