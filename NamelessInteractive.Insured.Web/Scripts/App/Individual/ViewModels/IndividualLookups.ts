module InsuredApp {
    export module ViewModels {
        export module Individual {
            export class IndividualLookup {
                Genders: Array<Gender>;
                Races: Array<Race>;
                MaritalStatuses: Array<MaritalStatus>;                
                constructor() {
                    this.Genders = [Gender.Create(1, "GEN01", "Male"), Gender.Create(2, "GEN02", "Female")]
                    this.Races = [Race.Create(1, "RACE01", "White"), Race.Create(2, "RACE02", "Black")];
                    this.MaritalStatuses = [MaritalStatus.Create(1, "MS01", "Married"), MaritalStatus.Create(2, "MS02", "Single")];
                }
            }
        }
    }
} 