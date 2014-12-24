module NamelessInteractive.Insured.Domain.Broker

open System
open NamelessInteractive.Insured.Domain.Shared
open NamelessInteractive.Insured.Domain.Party

type BrokerCategory =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type BrokerType =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type FSPNumber = FSPNumber of FSPNumber: string

type Broker =
    {
        Id: Identifier
        FSPNumber: FSPNumber option
        EffectiveDate: DateTime option
        ExpiryDate: DateTime option
        FSBApproved: bool option
        IGFApproved: bool option
        BrokerType: BrokerType option
        BrokerCategory: BrokerCategory option
        Party: Party option
        ComplianceOfficer: string
    }

