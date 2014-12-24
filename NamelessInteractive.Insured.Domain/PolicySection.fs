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
        Id: BigIdentifier
        Code: string
        Name: string
        SasriaApplicable: bool option
        SasriaSI: decimal option
        SasriaNumber: string
        NoOfUnits: int
        IsOriginal: bool
        RiskProfile: RiskProfile
        Sasria: Sasria
        Basis: Basis
        OccupactionCategory: OccupationCategory
        PolicySectionType: PolicySectionType
    }