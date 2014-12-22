module InsuredApp {
    export module ViewModels {
        export module Individual {
            export class Individual {
                Id: Core.Identifier;
                Name: PersonName;
                DateOfBirth: Date;
                Race: Race;
                MaritalStatus: MaritalStatus;
                Gender: Gender;
                Salutation: Salutation;
                IdentityNumber: IdentityNumber;
                PassportNumber: PassportNumber;
                Lookups: IndividualLookup;
                constructor() {
                    this.Lookups = new IndividualLookup();
                }

                static IfNull(a, b, c) {
                    return Utilities.Shared.ParseUtilities.IfNull(a, b, c);
                }

                static Parse(data: Individual) {
                    var result = new Individual();
                    result.Id = new Core.Identifier(data.Id.Identifier);
                    result.Name = PersonName.Create(data.Name.FirstName, data.Name.MiddleName, data.Name.LastName, data.Name.MaidenName);
                    result.DateOfBirth = data.DateOfBirth;
                    result.Race = Race.Create(data.Race.Id.Identifier, data.Race.Code, data.Race.Description);
                    result.MaritalStatus = MaritalStatus.Create(data.MaritalStatus.Id.Identifier, data.MaritalStatus.Code, data.MaritalStatus.Description);
                    result.Gender = Gender.Create(data.Gender.Id.Identifier, data.Gender.Code, data.Gender.Description);
                    result.Salutation = Salutation.Create(data.Salutation.Id.Identifier, data.Salutation.Code, data.Salutation.Description);
                    if (data.IdentityNumber != null && data.IdentityNumber != undefined) {
                        result.IdentityNumber = new IdentityNumber(data.IdentityNumber.IdentityNumber);
                    }
                    if (data.PassportNumber != null && data.PassportNumber != undefined) {
                        result.PassportNumber = new PassportNumber(data.PassportNumber.PassportNumber);
                    }
                    return result;
                }
            }
        }
    }
} 