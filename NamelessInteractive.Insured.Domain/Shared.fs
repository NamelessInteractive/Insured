module NamelessInteractive.Insured.Domain.Shared

open System

type Identifier = Identifier of int

type TelephoneNumber = TelephoneNumber of string

type EmailAddress = EmailAddress of string
type WebsiteUrl = WebsiteUrl of string

type ValidityInformation =
    {
        StartDate: DateTime
        EndDate: DateTime option
    }