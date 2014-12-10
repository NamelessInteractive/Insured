module NamelessInteractive.Insured.Domain.Risk

open NamelessInteractive.Insured.Domain.Shared

type RiskTypeInformation = 
    {
        Name: string
        ValidityInformation: ValidityInformation
    }

