module NamelessInteractive.Insured.Data.Risk

open NamelessInteractive.Insured.Domain.Risk

let private ParseRiskType reader: RiskType =
    {
        RiskType.Id = reader |> ReadInt "RiskTypeId" |> ParseId
        Code = reader |> ReadString "RiskTypeCode"
        Name = reader |> ReadString "RiskTypeName"
    }

let GetRiskTypes() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "SELECT * FROM RiskType"
        []
        ParseRiskType