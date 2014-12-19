module InsuredApp {
    export module ViewModels {
        export module Organisation {
            export class CompanyRegistrationNumber {
                constructor(companyRegistrationNumber: string) {
                    this.CompanyRegistrationNumber = companyRegistrationNumber;
                }
                CompanyRegistrationNumber: string;
            }
        }
    }
} 