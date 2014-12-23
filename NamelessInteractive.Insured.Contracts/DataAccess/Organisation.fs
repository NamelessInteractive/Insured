module NamelessInteractive.Insured.Contracts.DataAccess.Organisation

open NamelessInteractive.Insured.Domain.Organisation

type GetIndustries = unit -> Industry seq

type IndustryQueries =
    {
        GetIndustries: GetIndustries
    }

type GetIndustryClassifications = unit -> IndustryClassification seq

type IndustryClassificationQueries = 
    {
        GetIndustryClassifications:GetIndustryClassifications
    }

type GetOrganisationTypes = unit -> OrganisationType seq

type OrganisationTypeQueries = 
    {
        GetOrganisationTypes : GetOrganisationTypes
    }

type GetOrganisations = unit -> Organisation seq
type GetOrganisationById = int -> Organisation option

type OrganisationQueries = 
    {
        GetOrganisations : GetOrganisations
        GetOrganisationById: GetOrganisationById
    }