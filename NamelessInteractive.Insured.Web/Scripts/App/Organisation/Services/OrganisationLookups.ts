module InsuredApp {
    export module Services {
        export module Organisation {
            export class OrganisationLookupService {
                private $resource: ng.resource.IResourceService;
                private ParseOrganisationType(response) {
                    var data = response.data, key, value;
                    for (key in data) {
                        if (!data.hasOwnProperty(key)) {
                            continue;
                        }
                        data[key] = ViewModels.Organisation.OrganisationType.Create(data[key].Id.Identifier, data[key].Code, data[key].Description);
                    }
                    return response;
                }

                private ParseIndustry(response) {
                    var data = response.data, key, value;
                    for (key in data) {
                        if (!data.hasOwnProperty(key)) {
                            continue;
                        }
                        data[key] = ViewModels.Organisation.Industry.Create(data[key].Id.Identifier, data[key].Code, data[key].Description);
                    }
                    return response;
                }

                private ParseIndustryClassification(response) {
                    var data = response.data, key, value;
                    for (key in data) {
                        if (!data.hasOwnProperty(key)) {
                            continue;
                        }
                        data[key] = ViewModels.Organisation.IndustryClassification.Create(data[key].Id.Identifier, data[key].Code, data[key].Description, data[key].Category, data[key].IndustryCode);
                    }
                    return response;
                }
                constructor($resource: ng.resource.IResourceService) {
                    this.$resource = $resource;
                }

                GetOrganisationTypes() {
                    return this.$resource<ViewModels.Organisation.OrganisationType>("/Api/OrganisationType/", null, { "query": { method: 'GET', isArray: true, interceptor: { response: this.ParseOrganisationType } } }).query();
                }

                GetIndustries() {
                    return this.$resource<ViewModels.Organisation.OrganisationType>("/Api/Industry/", null, { "query": { method: 'GET', isArray: true, interceptor: { response: this.ParseIndustry } } }).query();
                }

                GetIndustryClassifications() {
                    return this.$resource<ViewModels.Organisation.IndustryClassification>("/Api/IndustryClassification/", null, { "query": { method: 'GET', isArray: true, interceptor: { response: this.ParseIndustryClassification } } }).query();
                }
            }
        }
    }
} 

Application.service('OrganisationLookupService', function OrganisationLookupService($resource: ng.resource.IResourceService) {
    return new InsuredApp.Services.Organisation.OrganisationLookupService($resource);
});