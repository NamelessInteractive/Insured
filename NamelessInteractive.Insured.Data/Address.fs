module NamelessInteractive.Insured.Data.Address

open NamelessInteractive.Insured.Domain.Address
open NamelessInteractive.Insured.Contracts
open System.Data

let private ParseCrestaZone reader : CrestaZone =
        {
            CrestaZone.Id = reader |> ReadInt "CrestaZoneId" |> ParseId
            CrestaZone.CrestaZone = reader |> ReadString "CrestaZone"
        }

let private ParseProvince reader : Province =
        {
            Province.Id = reader |> ReadInt "ProvinceId" |> ParseId
            Province.Code = reader |> ReadString "ProvinceCode"
            Province.Name = reader |> ReadString "ProvinceName"
        }

let internal ParseCountry reader: Country =
        {
            Country.Id = reader |> ReadInt "CountryId" |> ParseId
            Country.Code = reader |> ReadString "CountryCode"
            Country.Name = reader |> ReadString "CountryName"
        }

let private ParsePostalCode reader :PostalCode =
    PostalCode(reader |> ReadString "PostalCode")

let private ParseAddress reader : Address =
    {
        Address.Id = reader |> ReadInt "AddressId" |> ParseId
        Line1 = reader |> ReadString "AddressLine1"
        Line2 = reader |> ReadString "AddressLine2"
        Line3 = reader |> ReadString "AddressLine3"
        Line4 = reader |> ReadString "AddressLine4"
        PostalCode = reader |> ParsePostalCode
        CrestaZone = reader |> ReadOption "CrestaZoneId" ParseCrestaZone
        Province = reader |> ParseProvince
        Country = reader |> ParseCountry
    }

let GetCrestaZones() = 
    ExecuteReaderWithConnectionString 
        LogicalModelConnectionStringName 
        "SELECT * FROM CrestaZone"
        []
        ParseCrestaZone

let GetCountries() = 
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * from Country"
        []
        ParseCountry

let GetProvinces() : Province seq =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "SELECT * FROM Province"
        []
        ParseProvince

let private GetAddressesBaseQuery =
    """
        SELECT 
            * 
        FROM
            ADDRESS A
        INNER JOIN
            COUNTRY C ON C.CountryId = A.CountryID
        INNER JOIN 
            Province P on P.ProvinceId = A.ProvinceID
        INNER JOIN
            PostalCode PC on PC.PostalCodeId = A.PostalCodeId
        LEFT JOIN 
            CrestaZone CZ on CZ.CrestaZoneID = A.CrestaZoneID"""

let GetAddressByIdQuery = sprintf "%s WHERE AddressID = @Id" GetAddressesBaseQuery

let GetAddresses() : Address seq =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        GetAddressesBaseQuery
        []
        ParseAddress

let GetAddressById (id: int) : Address option =
    ExecuteRowWithConnectionString
        LogicalModelConnectionStringName
        GetAddressByIdQuery
        [
            "Id", box id
        ]
        ParseAddress
        