namespace NamelessInteractive.Insured.Web.Controllers.Api.Individual

open System.Web.Http
open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Individual

type IndividualController() =
    inherit ApiController()
    member this.Get() : Individual seq =
        Seq.empty<Individual>

    member this.Get(id: int) =
        { 
            Id = Shared.Identifier(100)
            Name = 
                {
                    PersonName.FirstName = "Kevin"
                    PersonName.LastName = "Ashton"
                    PersonName.MiddleName = Some("James")
                    PersonName.MaidenName = None
                }
            DateOfBirth = System.DateTime(1984,02,22)
            Race = 
                {
                    Race.Id = Shared.Identifier(1)
                    Code = "RACE01"
                    Description = "White"
                } |> Some
            MaritalStatus = 
                {
                    MaritalStatus.Id = Shared.Identifier(1)
                    Code = "MARSTAT02"
                    Description = "Married"
                } |> Some
            Gender = 
                {
                    Gender.Id = Shared.Identifier(1)
                    Code = "GEN01"
                    Description = "Male"
                } |> Some
            Salutation = 
                {
                    Salutation.Id = Shared.Identifier(1)
                    Code = "SAL01"
                    Description = "Sir"
                } |> Some
            IdentityNumber = Some(IdentityNumber("8402225157080"))
            PassportNumber = None
        }

