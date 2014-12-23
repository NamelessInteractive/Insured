module NamelessInteractive.Insured.Contracts.DataAccess.Business

open NamelessInteractive.Insured.Domain.Business

type GetClassesOfBusiness = unit -> ClassOfBusiness seq

type ClassOfBusinessQueries =
    {
        GetClassesOfBusiness: GetClassesOfBusiness
    }

type GetLinesOfBusiness = unit -> LineOfBusiness seq

type LineOfBusinessQueries =
    {
        GetLinesOfBusiness: GetLinesOfBusiness
    }

