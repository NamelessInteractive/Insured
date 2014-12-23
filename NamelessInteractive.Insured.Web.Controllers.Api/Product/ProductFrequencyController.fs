namespace NamelessInteractive.Insured.Web.Controllers.Api.Product

open NamelessInteractive.Insured.Contracts.DataAccess.Product
open NamelessInteractive.Insured.Web.Controllers.Api

type ProductFrequencyController() =
    inherit ApiControllerBase()
    let productFrequencyQueries = 
        {
            ProductFrequencyQueries.GetProductFrequencies = NamelessInteractive.Insured.Data.Product.GetProductFrequencies
        }
    member this.Get() =
        productFrequencyQueries.GetProductFrequencies()

