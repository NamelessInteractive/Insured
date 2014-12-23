module NamelessInteractive.Insured.Contracts.DataAccess.Address

open NamelessInteractive.Insured.Domain.Address

type GetCrestaZones = unit -> CrestaZone seq

type CrestaZoneQueries = 
    {
        GetCrestaZones: GetCrestaZones
    }

type GetCountries = unit -> Country seq

type CountryQueries =
    {
        GetCountries: GetCountries
    }

type GetProvinces = unit -> Province seq

type ProvinceQueries =
    {
        GetProvinces: GetProvinces
    }

type GetAddresses = unit -> Address seq
type GetAddressById = int -> Address option

type AddressQueries = 
    {
        GetAddresses : GetAddresses
        GetAddressById: GetAddressById
    }