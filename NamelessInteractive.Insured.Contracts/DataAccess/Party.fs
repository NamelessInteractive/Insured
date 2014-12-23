module NamelessInteractive.Insured.Contracts.DataAccess.Party

open NamelessInteractive.Insured.Domain.Party

type GetPartyTypes = unit -> PartyType seq

type PartyTypesQueries = 
    {
        GetPartyTypes: GetPartyTypes
    }

type GetCreditRatings = unit -> CreditRating seq

type CreditRatingQueries = 
    {
        GetCreditRatings: GetCreditRatings
    }

type GetLanguages = unit -> Language seq

type LanguageQueries =
    {
        GetLanguages: GetLanguages
    }

type GetCurrencies = unit -> Currency seq

type CurrencyQueries = 
    {
        GetCurrencies : GetCurrencies
    }

type GetParties = unit -> Party seq
type GetPartyById = int -> Party option

type PartyQueries = 
    {
        GetParties: GetParties
        GetPartyById: GetPartyById
    }