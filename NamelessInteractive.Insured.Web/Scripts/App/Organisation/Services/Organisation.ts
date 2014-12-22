module InsuredApp {
    export module Services {
        export module Organisation {
            export class OrganisationService {
                private $resource: ng.resource.IResourceService;
                private ParseOrganisation(data) {
                    return ViewModels.Organisation.Organisation.Parse(OrganisationService.OrganisationLookupService, JSON.parse(data));;
                }
                static OrganisationLookupService: Services.Organisation.OrganisationLookupService;
                constructor($resource, OrganisationLookupService) {
                    this.$resource = $resource;
                    OrganisationService.OrganisationLookupService = OrganisationLookupService;
                }

                Get(id: number) {
                    return this.$resource<ViewModels.Organisation.Organisation>("/Api/Organisation/" + id, null, { get: { method: "GET", transformResponse: this.ParseOrganisation, isArray: false  } }).get();
                }
            }
        }
    }
} 

Application.service("OrganisationService", function OrganisationService($resource, OrganisationLookupService: InsuredApp.Services.Organisation.OrganisationLookupService) {
    return new InsuredApp.Services.Organisation.OrganisationService($resource, OrganisationLookupService);
});