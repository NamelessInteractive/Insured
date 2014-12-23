module NamelessInteractive.Insured.Domain.Risk

open NamelessInteractive.Insured.Domain.Shared
open System

type RiskType = 
    {
        Id: Identifier
        Code: string
        Name: string
    }

type RiskProfile = 
    {
        Id: Identifier
        Description: string
        ZeroRatedIndicator: bool
        RetroActiveDate: DateTime
        RiskType: RiskType
    }

