namespace NamelessInteractive.Insured.Web.Controllers.Api

open System.Web.Http
open NamelessInteractive.Insured.Domain
open NamelessInteractive.Insured.Domain.Organisation

type OrganisationController() = 
    inherit ApiController()
    member this.Get() : Organisation seq =
        Seq.empty<Organisation>

    member this.Get(id: int) : Organisation =
        { 
            Id = Shared.Identifier(id)
            CompanyName = 
                {
                    CompanyName.RegisteredName = "Registered Company"
                    CompanyName.TradingName = "Trading Company"
                }
            CompanyRegistrationNumber = Some(CompanyRegistrationNumber("1"))
            VATNumber = Some(VATNumber("2"))
            PBOReferenceNumber = Some(PBOReferenceNumber("3"))
            IncomeTaxNumber = Some(IncomeTaxNumber("4"))
            EmailAddress = Some(Shared.EmailAddress("test@example.com"))
            Website = Some(Shared.WebsiteUrl("http://www.example.com"))
            Turnover = Some(100000M)
            ForeignIndicator = false
            ListedIndicator = true
            ParentOrganisation = None
            OrganisationType =
                {
                    OrganisationType.Id = Shared.Identifier(1)
                    OrganisationType.Code = "ORGTYPE"
                    OrganisationType.Description = "Organisation Type"
                }
            Industry = 
                {
                    Industry.Id = Shared.Identifier(1)
                    Industry.Code = "IND"
                    Industry.Description = "Industry Type"
                } |> Some
            IndustryClassification = None
            Directors = Seq.empty<Director>
            BEELevelDocuments = Seq.empty<BEELevelDocument>
        }

    member this.Post([<FromBody>]value: string) =
        ()

    member this.Put(id: int, [<FromBody>]value: string) =
        ()

    member this.Delete(id: int) =
        ()
