module NamelessInteractive.Insured.Domain.Cover

open NamelessInteractive.Insured.Domain.Shared
open NamelessInteractive.Insured.Domain.PolicySection

type CoverType =
    {
        Id: Identifier
        Code: string
        Description: string
        CoverType: string
    }

type Cover =
    {
        Id: Identifier
        Description: string
        DeclaredAmount: decimal
        SumInsuredLimit: decimal
        EMLAmount: decimal
        EMLPercentage: decimal
        SystemRate: decimal option
        SystemPremium: decimal option
        OverrideRate: decimal option
        OverridePremium: decimal option
        FinalRate: decimal option
        FinalPremium: decimal option
        NumberOfUnits: int
        CoverType: CoverType
        Basis: Basis
        PolicySection: PolicySection
    }