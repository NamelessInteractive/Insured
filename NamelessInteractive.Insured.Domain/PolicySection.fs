module NamelessInteractive.Insured.Domain.PolicySection

open NamelessInteractive.Insured.Domain.Shared
open NamelessInteractive.Insured.Domain.Risk

type Basis =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type Sasria =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type OccupationCategory =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type PolicySectionType =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type PolicySection =
    {
        Id: Identifier
        Code: string
        Name: string
        SasriaApplicable: bool
        SasriaSI: decimal
        SasriaNumber: string
        NoOfUnits: int
        RiskProfile: RiskProfile
        Sasria: Sasria
        Basis: Basis
        OccupactionCategory: OccupationCategory
        PolicySectionType: PolicySectionType
    }