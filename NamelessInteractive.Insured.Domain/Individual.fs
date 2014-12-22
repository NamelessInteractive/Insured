module NamelessInteractive.Insured.Domain.Individual

open System
open NamelessInteractive.Insured.Domain.Shared
open System.ComponentModel.DataAnnotations

type Race = 
    {
        Id: Identifier
        Code: string
        Description: string
    }

type MaritalStatus =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type Gender = 
    {
        Id: Identifier
        Code: string
        Description: string
    }

type Salutation = 
    {
        Id: Identifier
        Code: string
        Description: string
    }

type IdentityNumber = IdentityNumber of IdentityNumber: string
type PassportNumber = PassportNumber of PassportNumber: string
type IndividualIdentityType =
    | IdentityNumberOnly of IdentityNumber: IdentityNumber
    | PassportNumberOnly of PassportNumber: PassportNumber
    | IdentityNumberAndPassportNumber of IdentityNumber: IdentityNumber * PassportNumber: PassportNumber

type PersonName = 
    {
        [<Display(Name="First Name")>]
        [<Required>]
        FirstName: string
        [<Display(Name="Middle Name")>]
        MiddleName: string option
        [<Display(Name="Last Name")>]
        [<Required>]
        LastName: string
        [<Display(Name="Maiden Name")>]
        MaidenName: string option
    }

type Individual =
    {
        Id: Identifier
        [<Display(Name="Name")>]
        Name: PersonName
        [<Display(Name="Date of Birth")>]
        DateOfBirth: DateTime
        [<Display(Name="Race")>]
        Race: Race option
        [<Display(Name="Marital Status")>]
        MaritalStatus: MaritalStatus option
        [<Display(Name="Gender")>]
        Gender: Gender option
        [<Display(Name="Salutation")>]
        Salutation: Salutation option
        [<Display(Name="Identity Number")>]
        IdentityNumber: IdentityNumber option
        [<Display(Name="Passport Number")>]
        PassportNumber: PassportNumber option
    }