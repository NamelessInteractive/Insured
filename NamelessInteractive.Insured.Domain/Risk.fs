module NamelessInteractive.Insured.Domain.Risk

open NamelessInteractive.Insured.Domain.Shared
open System

type RiskType = 
    {
        Id: Identifier
        Code: string
        Name: string
    }
    static member Zero =
        {
            Id = Identifier(0)
            Code = "Not Applicable"
            Name = "Not Applicable"
        }

type RiskProfile = 
    {
        Id: Identifier
        Description: string
        ZeroRatedIndicator: bool
        RetroActiveDate: DateTime
        RiskType: RiskType
    }
    static member Zero =
        {
            Id = Identifier(0)
            Description = "Zero"
            ZeroRatedIndicator = true
            RetroActiveDate = DateTime.MinValue
            RiskType = RiskType.Zero
        }

