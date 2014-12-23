module NamelessInteractive.Insured.Domain.Branch

open Shared
open System.ComponentModel.DataAnnotations

type Branch =
    {
        Id: Identifier
        [<Required>]
        [<Display(Name="Branch Code")>]
        Code: string
        [<Required>]
        [<Display(Name="Description")>]
        Description: string
        Address: Address.Address
    }