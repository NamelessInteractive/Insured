namespace NamelessInteractive.Insured.Web.Controllers.Api.Organisation

open System.Web.Http
open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Organisation
open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Organisation

type OrganisationController() = 
    inherit ApiControllerBase()
    let organisationQueries = 
        {
            OrganisationQueries.GetOrganisationById = NamelessInteractive.Insured.Data.Organisation.GetOrganisationById
            OrganisationQueries.GetOrganisations = NamelessInteractive.Insured.Data.Organisation.GetOrganisations
        }
    member this.Get() : Organisation seq =
        organisationQueries.GetOrganisations()

    member this.Get(id: int) : Organisation option =
        organisationQueries.GetOrganisationById id

    member this.Post([<FromBody>]value: string) =
        ()

    member this.Put(id: int, [<FromBody>]value: string) =
        ()

    member this.Delete(id: int) =
        ()
