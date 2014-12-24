module NamelessInteractive.Insured.Data.Broker

open NamelessInteractive.Insured.Domain.Broker
open System.Data

let private ParseBrokerCategory reader : BrokerCategory =
    {
        BrokerCategory.Id = reader |> ReadInt "BrokerCategoryId" |> ParseId
        BrokerCategory.Code = reader |> ReadString "BrokerCategoryCode"
        BrokerCategory.Description = reader |> ReadString "BrokerCategoryDesc"
    }

let private ParseBrokerType reader : BrokerType =
    {
        BrokerType.Id = reader |> ReadInt "BrokerTypeId" |> ParseId
        Code = reader |> ReadString "BrokerTypeCode"
        Description = reader |> ReadString "BrokerTypeDesc"
    }

let private ParseFSPNumber reader :FSPNumber =
    reader |> ReadString "FSPNo" |> FSPNumber

let private ParseBroker (reader:IDataReader) : Broker =
    {
        Broker.Id = reader |> ReadInt "BrokerId" |> ParseId
        FSPNumber = reader |> ReadOption "FSPNo" ParseFSPNumber
        EffectiveDate = reader |> ReadDateNull "EffectiveDate"
        ExpiryDate = reader |> ReadDateNull "ExpiryDate"
        FSBApproved = reader |> ReadOption "FSBApproved" (ReadBool "FSBApproved")
        IGFApproved = reader |> ReadOption "IGFApproved" (ReadBool "IGFApproved")
        BrokerType = reader |> ReadOption "BrokerTypeId" ParseBrokerType
        BrokerCategory = reader |> ReadOption "BrokerCategoryId" ParseBrokerCategory
        Party = if reader.IsDBNull("PartyId") then None else reader |> ReadInt "PartyId" |> Party.GetPartyById
        ComplianceOfficer = reader |> ReadString "ComplianceOfficer"
    }

let GetBrokerCategories() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From BrokerCategory"
        []
        ParseBrokerCategory

let GetBrokerTypes() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From BrokerType"
        []
        ParseBrokerType

let private GetBrokersBaseQuery= 
    """
    SELECT
        *
    From 
        Broker B
    LEFT JOIN 
        BrokerType BT on BT.BrokerTypeId = B.BrokerTypeId
    LEFT JOIN
        BrokerCategory BC on BC.BrokerCategoryID =B.BrokerCategoryID
    LEFT JOIN 
        PartyRelationshipLink PRL on PRL.PartyRelationshipLinkID = B.PartyRelationshipLinkId
    """

let GetBrokers() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        GetBrokersBaseQuery
        []
        ParseBroker