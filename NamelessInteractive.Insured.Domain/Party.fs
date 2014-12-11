module NamelessInteractive.Insured.Domain.Party

open NamelessInteractive.Insured.Domain.Shared

type Party =
    {
        Id: Identifier
        Code: string
        Name: string
    }