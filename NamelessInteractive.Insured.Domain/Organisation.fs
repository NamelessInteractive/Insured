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

type CompanyRegistrationNumber = CompanyRegistrationNumber of CompanyRegistrationNumber:string
type VATNumber = VATNumber of VATNumber :string
type PBOReferenceNumber = PBOReferenceNumber of PBOReferenceNumber:string
type IncomeTaxNumber = IncomeTaxNumber of IncomeTaxNumber:string

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
        [<Display(Name="Company Registration Number")>]
        CompanyRegistrationNumber: CompanyRegistrationNumber option
        [<Display(Name="VAT Number")>]
        VATNumber: VATNumber option
        [<Display(Name="PBO Reference Number")>]
        PBOReferenceNumber: PBOReferenceNumber option
        [<Display(Name="Income Tax Number")>]
        IncomeTaxNumber: IncomeTaxNumber option
        [<Display(Name="Email Address")>]
        EmailAddress: EmailAddress option
        [<Display(Name="Website")>]
        Website: WebsiteUrl option
        [<Display(Name="Turnover")>]
        Turnover: decimal option
        [<Display(Name="Foreign")>]
        ForeignIndicator: bool
        [<Display(Name="Listed")>]
        ListedIndicator: bool
        [<Display(Name="Parent Organisation")>]
        ParentOrganisation: Organisation option
        [<Display(Name="Organisation Type")>]
        OrganisationType: OrganisationType
        [<Display(Name="Industry")>]
        Industry: Industry option
        [<Display(Name="Industry Classification")>]
        IndustryClassification: IndustryClassification option
        [<Display(Name="Directors")>]
        Directors: Director seq
        [<Display(Name="BEE Level Documents")>]
        BEELevelDocuments: BEELevelDocument seq
    }
    [<Display(Name="Parent Organisation")>]
    member this.ParentOrganisationName 
        with get() = 
            match this.ParentOrganisation with
            | None -> "None"
            | Some(org) -> org.CompanyName.RegisteredName