module NamelessInteractive.Insured.Contracts.DataAccess.PolicySection

open NamelessInteractive.Insured.Domain.PolicySection

type GetBasises = unit -> Basis seq
type BasisQueries = 
    {
        GetBasises : GetBasises
    }

type GetSasrias = unit -> Sasria seq

type SasriaQueries =
    {
        GetSasrias: GetSasrias
    }

type GetOccupationCategories = unit -> OccupationCategory seq

type OccupationCategoryQueries =
    {
        GetOccupationCategories: GetOccupationCategories
    }

type GetPolicySectionTypes = unit -> PolicySectionType seq

type PolicySectionTypeQueries =
    {
        GetPolicySectionTypes: GetPolicySectionTypes
    }

type GetPolicySections = unit -> PolicySection seq
type GetPolicySectionById = int64 -> PolicySection option

type PolicySectionQueries =
    {
        GetPolicySections: GetPolicySections
        GetPolicySectionById: GetPolicySectionById
    }