module NamelessInteractive.Insured.Domain.Shared

open System

type PostalCode = PostalCode of string

type Address = 
    {
        Line1: string
        Line2: string
        Line3: string
        Line4: string
        PostalCode: PostalCode
    }

type AddressInfo = 
    {
        Primary: Address
        Additional: Address list
    }

type TelephoneNumber = TelephoneNumber of string

type EmailAddress = EmailAddress of string

type PersonName = 
    {
        FirstName: string
        LastName: string
    }

type ValidityInformation =
    {
        StartDate: DateTime
        EndDate: DateTime
    }