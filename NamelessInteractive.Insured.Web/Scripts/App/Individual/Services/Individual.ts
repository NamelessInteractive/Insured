module InsuredApp {
    export module Services {
        export module Individual {
            export class IndividualService {
                private $resource: ng.resource.IResourceService;
                private ParseIndividual(data) {
                    return ViewModels.Individual.Individual.Parse(JSON.parse(data));
                }

                constructor($resource: ng.resource.IResourceService) {
                    this.$resource = $resource;
                }

                Get(id) {
                    return this.$resource<ViewModels.Individual.Individual>("/Api/Individual/" + id, null, {
                        get: { method: "GET", transformResponse: this.ParseIndividual }
                    }).get();
                }
            }
        }
    }
} 

Application.service('IndividualService', function IndividualService($resource: ng.resource.IResourceService) {
    return new InsuredApp.Services.Individual.IndividualService($resource);
});