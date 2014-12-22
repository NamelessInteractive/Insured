module InsuredApp {
    export module ViewModels {
        export module Organisation {
            export class OrganisationLookups {
                OrganisationTypes: Array<OrganisationType>;
                Industries: Array<Industry>;
                IndustryClassifications: Array<IndustryClassification>;
                constructor(OrganisationLookupService: Services.Organisation.OrganisationLookupService) {
                    this.OrganisationTypes = OrganisationLookupService.GetOrganisationTypes();
                    this.Industries = OrganisationLookupService.GetIndustries();
                    this.IndustryClassifications = OrganisationLookupService.GetIndustryClassifications();
                }
            }
        }
    }
} 