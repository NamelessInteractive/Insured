module NamelessInteractive.Insured.Data.Business

open NamelessInteractive.Insured.Domain.Business

let private ParseClassOfBusiness reader : ClassOfBusiness =
    {
        ClassOfBusiness.Id = reader |> ReadInt "ClassOfBusinessId" |> ParseId
        Code = reader |> ReadString "ClassOfBusinessCode"
        Description = reader |> ReadString "ClassOfBusinessName"
    }

let private ParseLineOfBusiness reader : LineOfBusiness =
    {
        LineOfBusiness.Id = reader |> ReadInt "LineOfBusinessId" |> ParseId
        Code = reader |> ReadString "LineOfBusinessCode"
        Description = reader |> ReadString "LineOfBusinessName"
        ClassOfBusiness = reader |> ParseClassOfBusiness
    }

let GetClassesOfBusiness() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From ClassOfBusiness"
        []
        ParseClassOfBusiness

let GetLinesOfBusiness() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        """
        SELECT
            *
        FROM
            LineOfBusiness LOB
        INNER JOIN
            ClassOfBusiness COB ON COB.ClassOfBusinessID = LOB.ClassOfBusinessID
        """
        []
        ParseLineOfBusiness