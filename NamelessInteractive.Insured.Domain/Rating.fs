module NamelessInteractive.Insured.Domain.Rating

open NamelessInteractive.Insured.Domain.Shared
open NamelessInteractive.Insured.Domain.Cover
open NamelessInteractive.Insured.Domain.Commission
open NamelessInteractive.Insured.Domain.Business
open NamelessInteractive.Insured.Domain.Peril

type RatingSection =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type Rating =
    {
        Id: Identifier
        ExposureLimit: decimal
        ThisPremium: decimal
        ThisPremiumVAT: decimal
        ThisCommission: decimal
        ThisCommissionVAT: decimal
        AnnualPremium: decimal
        Cover: Cover
        RatingSection: RatingSection
        CommissionByClassOfBusiness: CommissionByClassOfBusiness
        LineOfBusiness: LineOfBusiness
        PerilType: PerilType
    }