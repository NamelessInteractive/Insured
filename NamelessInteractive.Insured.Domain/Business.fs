module NamelessInteractive.Insured.Domain.Business

open NamelessInteractive.Insured.Domain.Shared

type ClassOfBusiness =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type LineOfBusiness =
    {
        Id:Identifier
        Code: string
        Description: string
        ClassOfBusiness: ClassOfBusiness
    }