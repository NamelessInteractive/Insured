module InsuredApp {
    export module ViewModels {
        export module Individual {
            export class Salutation {
                Id: Core.Identifier;
                Code: string;
                Description: string;
                constructor() {
                }

                static Create(id: number, code: string, description: string) {
                    var result = new Salutation();
                    result.Id = new Core.Identifier(id);
                    result.Code = code;
                    result.Description = description;
                    return result;
                }
            }
        }
    }
} 