module NamelessInteractive.Insured.Contracts.DataAccess.Product

open NamelessInteractive.Insured.Domain.Product

type GetProductFrequencies = unit -> ProductFrequency seq

type ProductFrequencyQueries = 
    {
        GetProductFrequencies: GetProductFrequencies
    }

type GetProducts = unit -> Product seq

type ProductQueries =
    {
        GetProducts: GetProducts
    }