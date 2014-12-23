module NamelessInteractive.Insured.Domain.Party

open NamelessInteractive.Insured.Domain.Shared

type PartyType = 
    {
        Id: Identifier
        Description: string
    }

type CreditRating =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type Language =
    {
        Id: Identifier
        Description: string
    }

type Currency =
    {
        Id: Identifier
        CurrencyType: string
        ISOCode: string
    }

type Party =
    {
        Id: Identifier
        Code: string
        Name: string
        CreditRating: CreditRating
        Language: Language
        Currency: Currency
        PartyType: PartyType
    }