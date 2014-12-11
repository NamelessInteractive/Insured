module NamelessInteractive.Insured.Domain.Individual

open System

type Race = 
    {
        Id: int
        Code: string
        Description: string
    }

type MaritalStatus =
    {
        Id: int
        Code: string
        Description: string
    }

type Gender = 
    {
        Id: int
        Code: string
        Description: string
    }

type Salutation = 
    {
        Id: int
        Code: string
        Description: string
    }

type IdentityNumber = IdentityNumber of string
type PassportNumber = PassportNumber of string
type IndividualIdentityType =
    | IdentityNumberOnly of IdentityNumber
    | PassportNumberOnly of PassportNumber
    | IdentityNumberAndPassportNumber of IdentityNumber * PassportNumber

type PersonName = 
    {
        FirstName: string
        MiddleName: string option
        LastName: string
        MaidenName: string option
    }

type Individual =
    {
        Id: int
        Name: PersonName
        DateOfBirth: DateTime
        Race: Race option
        MaritalStatus: MaritalStatus option
        Gender: Gender option
        Salutation: Salutation option
        IdentityType: IndividualIdentityType
    }