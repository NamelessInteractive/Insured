module NamelessInteractive.Insured.Data.Product

open NamelessInteractive.Insured.Domain.Product
open NamelessInteractive.Insured.Domain.Shared

let private ParseProductFrequency reader : ProductFrequency =
    {
        ProductFrequency.Description = reader |> ReadString "ProductFrequency"
    }

let private ParseProductValidity reader : ValidityInformation =
    {
        ValidityInformation.StartDate = reader |> ReadDateTime "EffectiveDate"
        ValidityInformation.EndDate = reader |> ReadDateNull "ExpiryDate"
    }

let private ParseProduct reader : Product =
    {
        Product.Id = reader |> ReadInt "ProductId" |> ParseId
        Code = reader |> ReadString "ProductCode"
        Name = reader |> ReadString "ProductName"
        ProductFrequency = reader |> ParseProductFrequency
        ValidityInformation = reader |> ParseProductValidity
    }

let GetProductFrequencies() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select Distinct(ProductFrequency) From Product"
        []
        ParseProductFrequency

let GetProducts() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From Product"
        []
        ParseProduct