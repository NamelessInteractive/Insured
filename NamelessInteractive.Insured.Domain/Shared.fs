module NamelessInteractive.Insured.Domain.Shared

open System

type Identifier = Identifier of Identifier :int

type TelephoneNumber = TelephoneNumber of TelephoneNumber:string

type EmailAddress = EmailAddress of EmailAddress: string
type WebsiteUrl = WebsiteUrl of WebsiteUrl :string

type ValidityInformation =
    {
        StartDate: DateTime
        EndDate: DateTime option
    }