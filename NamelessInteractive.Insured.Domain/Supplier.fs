module NamelessInteractive.Insured.Domain.Supplier

open NamelessInteractive.Insured.Domain.Shared

type SupplierPaymentTerm =
    {
        Id: Identifier
        PaymentDays: int option
        PaymentMode: string
        PaymentSchedule: string
    }

type SupplierType =
    {
        Id: Identifier
        Code: string
        Description: string
    }

type SupplierGroup =
    {
        Id: Identifier
        Code: string
        Description: string
    }