namespace NamelessInteractive.Insured.Web.Controllers.Api.Organisation

open System.Web.Http
open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Organisation
open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Organisation

type OrganisationTypeController() = 
    inherit ApiControllerBase()
    let organisationTypeQueries = 
        {
            OrganisationTypeQueries.GetOrganisationTypes = NamelessInteractive.Insured.Data.Organisation.GetOrganisationTypes
        }
    member this.Get() : OrganisationType seq =
        organisationTypeQueries.GetOrganisationTypes()