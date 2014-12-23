module NamelessInteractive.Insured.Data.Organisation

open NamelessInteractive.Insured.Domain.Organisation
open NamelessInteractive.Insured.Contracts
open System.Data
open NamelessInteractive.Insured.Domain.Shared

let private ParseIndustry reader : Industry =
    {
        Industry.Id = reader |> ReadInt "IndustryId" |> ParseId
        Industry.Code = reader |> ReadString "IndustryCode"
        Industry.Description = reader |> ReadString "IndustryDesc"
    }

let private ParseIndustryClassification reader : IndustryClassification =
    {
        IndustryClassification.Id = reader |> ReadInt "IndustryClassificationId" |> ParseId
        Code = reader |> ReadString "IndustryClassificationCode"
        Description = reader |> ReadString "IndustryClassificationDesc"
        Category = reader |> ReadString "Category"
        IndustryCode = reader |> ReadString "IndustryCode"
    }

let private ParseOrganisationType reader :OrganisationType =
    {
        OrganisationType.Id = reader |> ReadInt "OrganisationTypeId" |> ParseId
        Code = reader |> ReadString "OrganisationType"
        Description = reader |> ReadString "OrganisationTypeDesc"
    }

let private ParseCompanyName reader : CompanyName =
    {
        CompanyName.RegisteredName = reader |> ReadString "RegisteredName"
        TradingName = reader |> ReadString "TradingName"
    }

let private ParseCompanyRegistrationNumber reader : CompanyRegistrationNumber =
    reader |> ReadString "CompanyRegNo" |> CompanyRegistrationNumber

let private ParseVATNumber reader :VATNumber =
    reader |> ReadString "VatNo" |> VATNumber

let private ParsePBOReferenceNumber reader : PBOReferenceNumber =
    reader |> ReadString "PBOReferenceNo" |> PBOReferenceNumber

let private ParseIncomeTaxNumber reader :IncomeTaxNumber =
    reader |> ReadString "IncomeTaxNo" |> IncomeTaxNumber

let private ParseEmailAddress reader : EmailAddress =
    reader |> ReadString "EmailAddress" |> EmailAddress

let private ParseWebsite reader :WebsiteUrl =
    reader |> ReadString "Website" |> WebsiteUrl

let private ParseOrganisation reader : Organisation =
    {
        Organisation.Id = reader |> ReadInt "OrganisationId" |> ParseId
        CompanyName = reader |> ParseCompanyName
        CompanyRegistrationNumber = reader |> ReadOption "CompanyRegNo" ParseCompanyRegistrationNumber
        VATNumber = reader |> ReadOption "VatNo" ParseVATNumber
        PBOReferenceNumber = reader |> ReadOption "PBOReferenceNo" ParsePBOReferenceNumber
        IncomeTaxNumber = reader |> ReadOption "IncomeTaxNo" ParseIncomeTaxNumber
        EmailAddress = reader |> ReadOption "EmailAddress" ParseEmailAddress
        Website = reader |> ReadOption "Website" ParseWebsite
        Turnover = reader |> ReadOption "Turnover" (ReadDecimal "Turnover")
        ForeignIndicator = reader |> ReadOption "ForeignIndicator" (ReadBool "ForeignIndicator")
        ListedIndicator = reader |> ReadOption "ListedIndicator" (ReadBool "ListedIndicator")
        ParentOrganisation = None
        CountryOperation = reader |> Address.ParseCountry
        OrganisationType = reader |> ParseOrganisationType
        Industry = reader |> ParseIndustry
        IndustryClassification = reader |> ParseIndustryClassification
        Directors = Seq.empty<Director>
        BEELevelDocuments = Seq.empty<BEELevelDocument>
    }

let GetIndustries() : Industry seq =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * from Industry"
        []
        ParseIndustry

let GetIndustryClassifications() : IndustryClassification seq =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From IndustryClassification"
        []
        ParseIndustryClassification

let GetOrganisationTypes() : OrganisationType seq =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * from OrganisationType"
        []
        ParseOrganisationType

let private GetOrganisationsBaseQuery = 
    """
    SELECT
        *
    FROM
        Organisation O
    INNER JOIN
       Country C on C.CountryId = O.CountryOperationId
    INNER JOIN 
        OrganisationType OT on OT.OrganisationTypeID = O.OrganisationTypeID
    INNER JOIN
        Industry I ON I.IndustryID = O.IndustryID
    INNER JOIN 
        IndustryClassification IC on IC.IndustryClassificationID = O.IndustryClassificationID
    """

let GetOrganisationByIdQuery = sprintf "%s WHERE OrganisationId = @Id" GetOrganisationsBaseQuery

let GetOrganisations(): Organisation seq =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        GetOrganisationsBaseQuery
        []
        ParseOrganisation

let GetOrganisationById (id:int) : Organisation option =
    ExecuteRowWithConnectionString
        LogicalModelConnectionStringName
        GetOrganisationByIdQuery
        [
            "Id", box id
        ]
        ParseOrganisation