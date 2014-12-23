namespace NamelessInteractive.Insured.Web.Controllers.Api.Product

open NamelessInteractive.Insured.Contracts.DataAccess.Product
open NamelessInteractive.Insured.Web.Controllers.Api

type ProductController() =
    inherit ApiControllerBase()
    let productQueries = 
        {
            ProductQueries.GetProducts = NamelessInteractive.Insured.Data.Product.GetProducts
        }
    member this.Get() =
        productQueries.GetProducts()

