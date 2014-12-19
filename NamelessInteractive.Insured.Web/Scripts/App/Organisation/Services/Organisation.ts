module InsuredApp {
    export module Services {
        export module Organisation {
            export class OrganisationService {
                private $resource: ng.resource.IResourceService;
                constructor($resource) {
                    this.$resource = $resource;
                }

                Get(id: number) {
                    return this.$resource<ng.resource.IResource<ViewModels.Organisation.Organisation>>("/Api/Organisation/" + id).get();
                }
            }
        }
    }
} 

Application.service("OrganisationService", function OrganisationService($resource) {
    return new InsuredApp.Services.Organisation.OrganisationService($resource);
});