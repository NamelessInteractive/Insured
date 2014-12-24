module NamelessInteractive.Insured.Contracts.DataAccess.Broker

open NamelessInteractive.Insured.Domain.Broker

type GetBrokerCategories = unit -> BrokerCategory seq

type BrokerCategoryQueries =
    {
        GetBrokerCategories: GetBrokerCategories
    }

type GetBrokerTypes = unit -> BrokerType seq

type BrokerTypeQueries =    
    {
        GetBrokerTypes: GetBrokerTypes
    }

type GetBrokers = unit -> Broker seq

type BrokerQueries =
    {
        GetBrokers: GetBrokers
    }