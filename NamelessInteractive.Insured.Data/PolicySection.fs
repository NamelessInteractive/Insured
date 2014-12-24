module NamelessInteractive.Insured.Data.PolicySection

open NamelessInteractive.Insured.Domain.PolicySection
open NamelessInteractive.Insured.Domain.Risk

let private ParseBasis reader : Basis =
    {
        Basis.Id = reader |> ReadInt "BasisId" |> ParseId
        Basis.Code = reader |> ReadString "BasisCode"
        Basis.Description = reader |> ReadString "BasisDesc"
    }

let private ParseSasria reader : Sasria =
    {
        Sasria.Id = reader |> ReadInt "SasriaId" |> ParseId
        Code = reader |> ReadString "SasriaCode"
        Description = reader |> ReadString "SasriaDesc"
    }

let private ParseOccupationCategory reader: OccupationCategory =
    {
        OccupationCategory.Id = reader |> ReadInt "OccupationCategoryId" |> ParseId
        Code = reader |> ReadString "OccupationCategoryCode"
        Description = reader |> ReadString "OccupationCategoryDesc"
    }

let private ParsePolicySectionType reader : PolicySectionType =
    {
        PolicySectionType.Id = reader |> ReadInt "PolicySectionTypeId" |> ParseId
        Code = reader |> ReadString "PolicySectionTypeCode"
        Description = reader |> ReadString "PolicySectionTypeDesc"
    }

let private ParsePolicySection reader : PolicySection =
    {
        PolicySection.Id = reader |> ReadBigInt "PolicySectionId" |> ParseBigId
        Code = reader |> ReadString "PolicySectionCode"
        Name = reader |> ReadString "PolicySectionName"
        SasriaApplicable = reader |> ReadOption "SasriaApplicable" (ReadBool "SasriaApplicable")
        SasriaSI = reader |> ReadOption "SasriaSI" (ReadDecimal "SasriaSI")
        IsOriginal = reader |> ReadBool "IsOriginal"
        SasriaNumber = reader |> ReadString "SariaNumber"
        NoOfUnits = reader |> ReadInt "NoOfUnits"
        RiskProfile = RiskProfile.Zero
        Sasria = reader |> ParseSasria
        Basis = reader |> ParseBasis
        OccupactionCategory = reader |> ParseOccupationCategory
        PolicySectionType = reader |> ParsePolicySectionType
    }    

let GetBasises() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From Basis"
        []
        ParseBasis

let GetSasrias() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * from Sasria"
        []
        ParseSasria

let GetOccupationCategories() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From OccupationCategory"
        []
        ParseOccupationCategory

let GetPolicySectionTypes() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * from PolicySectionType"
        []
        ParsePolicySectionType

let private GetPolicySectionBaseQuery =
    """
    SELECT
        *
    FROM
        PolicySection PS
    INNER JOIN
        Sasria S on S.SasriaID = PS.SasriaID
    INNER JOIN 
        Basis B on B.BasisId = PS.BasisID
    INNER JOIN
        OccupationCategory OC on OC.OccupationCategoryID = PS.OccupationCategoryID
    INNER JOIN 
        PolicySectionType PST on PST.PolicySectionTypeId = PS.PolicySectionTypeID
    """
    
let private GetPolicySectionByIdQuery = sprintf "%s where PolicySectionId = @Id" GetPolicySectionBaseQuery

let GetPolicySections() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        GetPolicySectionBaseQuery
        []
        ParsePolicySection

let GetPolicySectionById (id:int64) =
    ExecuteRowWithConnectionString
        LogicalModelConnectionStringName
        GetPolicySectionByIdQuery
        [
            "Id", box id
        ]
        ParsePolicySection
        