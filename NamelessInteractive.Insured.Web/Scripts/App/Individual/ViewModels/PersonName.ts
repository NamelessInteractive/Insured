module InsuredApp {
    export module ViewModels {
        export module Individual {
            export class PersonName {
                FirstName: string;
                LastName: string;
                MiddleName: string;
                MaidenName: string;
                constructor() {
                }

                static Create(firstName: string, middleName: string, lastName: string, maidenName: string) {
                    var result = new PersonName();
                    result.FirstName = firstName;
                    result.MiddleName = middleName;
                    result.LastName = lastName;
                    result.MaidenName = maidenName;
                    return result;
                }
            }
        }
    }
} 