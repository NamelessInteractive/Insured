module NamelessInteractive.Insured.Domain.Product

open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Shared

type ProductFrequency = 
    {
        Description: string
    }

type Product =
    {
        Id: Identifier
        Code: string
        Name: string
        ProductFrequency: ProductFrequency
        ValidityInformation: ValidityInformation
    }

