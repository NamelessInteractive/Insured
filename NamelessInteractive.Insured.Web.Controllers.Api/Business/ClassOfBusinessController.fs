namespace NamelessInteractive.Insured.Web.Controllers.Api.Business

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Business

type ClassOfBusinessController() =
    inherit ApiControllerBase()
    let classOfBusinessQueries =
        {
            ClassOfBusinessQueries.GetClassesOfBusiness = NamelessInteractive.Insured.Data.Business.GetClassesOfBusiness
        }
    member this.Get() =
        classOfBusinessQueries.GetClassesOfBusiness()