module NamelessInteractive.Insured.Domain.Customer

open NamelessInteractive.Insured.Domain.Shared
open NamelessInteractive.Insured.Domain.Address

type CommercialCustomerContact = 
    {
        Name: PersonName
    }

type CommercialCustomerInfo =
    {
        TradingName: string
        PhysicalAddress: AddressInfo
        PostalAddress: AddressInfo
    }

type PersonalCustomerInfo = 
    {
        Name: PersonName
        PhysicalAddress: AddressInfo
        PostalAddress: AddressInfo
    }

type Customer =
    | PersonalCustomer of PersonalCustomerInfo
    | CommercialCustomer of CommercialCustomerInfo