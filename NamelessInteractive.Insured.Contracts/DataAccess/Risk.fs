module NamelessInteractive.Insured.Contracts.DataAccess.Risk

open NamelessInteractive.Insured.Domain.Risk

type GetRiskTypes = unit -> RiskType seq

type RiskTypeQueries =
    {
        GetRiskTypes : GetRiskTypes
    }