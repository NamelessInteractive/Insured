module NamelessInteractive.Insured.Domain.Organisation

open NamelessInteractive.Insured.Domain.Shared
open NamelessInteractive.Insured.Domain.Document
open NamelessInteractive.Insured.Domain.Party
open System.ComponentModel.DataAnnotations

type Industry =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type IndustryClassification =
    {
        Id: Identifier
        Code: string
        Description: string
        Category: string
        IndustryCode: string
    }

type OrganisationType =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type BEELevel =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type BEELevelDocument = 
    {
        Id: Identifier
        Validity: ValidityInformation
        Document: Document
    }

type Director = 
    {
        Id: Identifier
        Validity: ValidityInformation
        Party: Party
    }

type CompanyRegistrationNumber = CompanyRegistrationNumber of string
type VATNumber = VATNumber of string
type PBOReferenceNumber = PBOReferenceNumber of string
type IncomeTaxNumber = IncomeTaxNumber of string

type CompanyName = 
    {
        [<Display(Name="Registered Name")>]
        [<Required>]
        RegisteredName: string
        [<Display(Name="Trading Name")>]
        TradingName: string
    }

type Organisation =
    {
        Id: Identifier
        CompanyName: CompanyName
        CompanyRegistrationNumber: CompanyRegistrationNumber option
        VATNumber: VATNumber option
        PBOReferenceNumber: PBOReferenceNumber option
        IncomeTaxNumber: IncomeTaxNumber option
        EmailAddress: EmailAddress option
        Website: WebsiteUrl option
        Turnover: decimal option
        ForeignIndicator: bool
        ListedIndicator: bool
        ParentOrganisation: Organisation option
        OrganisationType: OrganisationType
        Industry: Industry option
        IndustryClassification: IndustryClassification option
        Director: Director seq
        BEELevelDocuments: BEELevelDocument seq
    }