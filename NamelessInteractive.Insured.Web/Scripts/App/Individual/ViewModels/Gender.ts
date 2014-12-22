module InsuredApp {
    export module ViewModels {
        export module Individual {
            export class Gender {
                Id: Core.Identifier;
                Code: string;
                Description: string;
                constructor() {
                }

                static Create(id: number, code: string, description: string) {
                    var result = new Gender();
                    result.Id = new Core.Identifier(id);
                    result.Code = code;
                    result.Description = description;
                    return result;
                }
            }
        }
    }
} 