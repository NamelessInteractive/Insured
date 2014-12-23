module NamelessInteractive.Insured.Domain.Peril

open NamelessInteractive.Insured.Domain.Shared
open NamelessInteractive.Insured.Domain.Cover

type PerilType =
    {
        Id: Identifier
        PerilType: string
        Code: string
        SumIndicator:bool
        MaxIndicator: bool
    }

type PerilItem =
    {
        Id: Identifier
        Description: string
        Limit: decimal
        Premium: decimal
        Cover: Cover
        PerilType: PerilType
    }