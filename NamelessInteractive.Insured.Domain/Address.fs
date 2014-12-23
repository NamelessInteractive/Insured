module NamelessInteractive.Insured.Domain.Address

open NamelessInteractive.Insured.Domain.Shared

type PostalCode = PostalCode of PostalCode: string

type CrestaZone = 
    {
        Id: Identifier
        CrestaZone: string
    }

type Country =
    {
        Id: Identifier
        Code: string
        Name: string
    }

type Province = 
    {
        Id: Identifier
        Code: string
        Name: string
    }

type Address = 
    {
        Id: Identifier
        Line1: string
        Line2: string
        Line3: string
        Line4: string
        PostalCode: PostalCode
        CrestaZone: CrestaZone option
        Province: Province
        Country: Country
    }

type AddressInfo = 
    {
        Primary: Address
        Additional: Address list
    }