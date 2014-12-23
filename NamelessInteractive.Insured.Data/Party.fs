module NamelessInteractive.Insured.Data.Party

open NamelessInteractive.Insured.Domain.Party

let private ParsePartyType reader : PartyType =
    {
        PartyType.Id = reader |> ReadInt "PartyTypeId" |> ParseId
        PartyType.Description = reader |> ReadString "PartyTypeDesc"
    }

let private ParseCreditRating reader : CreditRating =
    {
        CreditRating.Id = reader |> ReadInt "CreditRatingId" |> ParseId
        Code = reader |> ReadString "CreditRatingCode"
        Description = reader |> ReadString "CreditRatingDesc"
    }

let private ParseLanguage reader : Language =
    {
        Language.Id = reader |> ReadInt "LanguageId" |> ParseId
        Language.Description = reader |> ReadString "LanguageDesc"
    }

let private ParseCurrency reader : Currency =
    {
        Currency.Id = reader |> ReadInt "CurrencyId" |> ParseId
        CurrencyType = reader |> ReadString "CurrencyType"
        ISOCode = reader |> ReadString "ISOCode"
    }

let private ParseParty reader : Party =
    {
        Party.Id = reader |> ReadInt "PartyId" |> ParseId
        Code = reader |> ReadString "PartyCode"
        Name = reader |> ReadString "PartyName"
        CreditRating = reader |> ParseCreditRating
        Language = reader |> ParseLanguage
        Currency = reader |> ParseCurrency
        PartyType = reader |> ParsePartyType
    }

let GetPartyTypes() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From PartyType"
        []
        ParsePartyType

let GetCreditRatings() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * from CreditRating"
        []
        ParseCreditRating

let GetLanguages() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * from Language"
        []
        ParseLanguage

let GetCurrencies() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From Currency"
        []
        ParseCurrency

let private GetPartiesBaseQuery = 
    """
    SELECT
        *
    FROM
        PARTY P
    INNER JOIN
        CreditRating CR on CR.CreditRatingID = P.CreditRatingID
    INNER JOIN
        Language L on L.LanguageID = P.LanguageID
    INNER JOIN
        Currency C on C.CurrencyId = P.CurrencyID
    INNER JOIN
        [PartyRelationshipLink] PRL on PRL.PartyID = P.PartyID
    INNER JOIN
        PartyType PT on PT.PartyTypeID = PRL.PartyTypeID
    """

let private GetPartyByIdQuery = sprintf "%s where P.PartyID = @Id" GetPartiesBaseQuery

let GetParties() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        GetPartiesBaseQuery
        []
        ParseParty

let GetPartyById (id:int) =
    ExecuteRowWithConnectionString
        LogicalModelConnectionStringName
        GetPartyByIdQuery
        [
            "Id", box id
        ]
        ParseParty