module InsuredApp {
    export module ViewModels {
        export module Organisation {
            export class Organisation {
                Id: Core.Identifier;
                CompanyName: CompanyName;
                CompanyRegistrationNumber: CompanyRegistrationNumber;
                VATNumber: VATNumber;
                PBOReferenceNumber: PBOReferenceNumber;
                IncomeTaxNumber: IncomeTaxNumber;
                EmailAddress: Shared.EmailAddress;
                Website: Shared.WebsiteUrl;
                Turnover: number;
                ForeignIndicator: boolean;
                ListedIndicator: boolean;
                ParentOrganisation: Organisation;
                ParentOrganisationName: string;
                OrganisationType: OrganisationType;
                Industry: Industry;
                IndustryClassification: IndustryClassification;
                Directors: Array<Director>;
                BEELevelDocuments: Array<BEELevelDocument>;
                constructor() {
                    this.CompanyRegistrationNumber = new CompanyRegistrationNumber(null);
                    this.VATNumber = new VATNumber(null);
                    this.PBOReferenceNumber = new PBOReferenceNumber(null);
                    this.IncomeTaxNumber = new IncomeTaxNumber(null);
                }

                private static IfNull(nullTestValue, value, defaultValue) {
                    return Utilities.Shared.ParseUtilities.IfNull(nullTestValue, value, defaultValue);
                }

                static Parse(data: Organisation) {
                    var result = new Organisation();
                    result.Id = new Core.Identifier(data.Id.Identifier);
                    result.CompanyName = CompanyName.Create(data.CompanyName.RegisteredName, data.CompanyName.TradingName);
                    result.CompanyRegistrationNumber.CompanyRegistrationNumber = Organisation.IfNull(data.CompanyRegistrationNumber, data.CompanyRegistrationNumber.CompanyRegistrationNumber, null);
                    result.VATNumber.VATNumber = Organisation.IfNull(data.VATNumber, data.VATNumber.VATNumber, null);
                    result.PBOReferenceNumber.PBOReferenceNumber = Organisation.IfNull(data.PBOReferenceNumber, data.PBOReferenceNumber.PBOReferenceNumber, null);
                    result.IncomeTaxNumber.IncomeTaxNumber = Organisation.IfNull(data.IncomeTaxNumber, data.IncomeTaxNumber.IncomeTaxNumber, null);
                    result.EmailAddress = new Shared.EmailAddress(Organisation.IfNull(data.EmailAddress, data.EmailAddress.EmailAddress, null));
                    result.Website = new Shared.WebsiteUrl(Organisation.IfNull(data.Website, data.Website.WebsiteUrl, null));
                    result.Turnover = data.Turnover;
                    result.ForeignIndicator = data.ForeignIndicator;
                    result.ListedIndicator = data.ListedIndicator;
                    result.ParentOrganisationName = data.ParentOrganisationName;
                    result.OrganisationType = OrganisationType.Create(data.OrganisationType.Id.Identifier, data.OrganisationType.Code, data.OrganisationType.Description);
                    if (data.Industry != null && data.Industry != undefined) {
                        result.Industry = Industry.Create(data.Industry.Id.Identifier, data.Industry.Code, data.Industry.Description);
                    }
                    if (data.IndustryClassification != null && data.IndustryClassification != undefined) {
                        result.IndustryClassification = IndustryClassification.Create(data.IndustryClassification.Id.Identifier, data.IndustryClassification.Code, data.IndustryClassification.Description, data.IndustryClassification.Category, data.IndustryClassification.IndustryCode);
                    }
                    return result;
                }

                static Test() {
                    var result = new Organisation();
                    result.Id = new Core.Identifier(100);
                    result.CompanyName = new CompanyName();
                    result.CompanyName.TradingName = "Trading Company";
                    result.CompanyName.RegisteredName = "Registered Company";
                    return result;
                }
            }
        }
    }
}