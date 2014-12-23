namespace NamelessInteractive.Insured.Web.Controllers.Api.Address

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Address

type ProvinceController() =
    inherit ApiControllerBase()
    let provinceQueries: ProvinceQueries =
        {
            GetProvinces = NamelessInteractive.Insured.Data.Address.GetProvinces
        }
    member this.Get() =
        provinceQueries.GetProvinces()

