module NamelessInteractive.Insured.Domain.Product

open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Shared

type ProductInformation =
    {
        Name: string
        ValidityInformation: ValidityInformation
    }

type Product = Product of ProductInformation * validRiskTypes : Risk.RiskTypeInformation