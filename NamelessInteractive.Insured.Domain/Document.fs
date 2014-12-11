module NamelessInteractive.Insured.Domain.Document

open NamelessInteractive.Insured.Domain.Shared

type DocumentType = 
    {
        Id: Identifier
        Description: string
    }

type Document =
    {
        Id: Identifier
        Description: string
        Path: string
    }