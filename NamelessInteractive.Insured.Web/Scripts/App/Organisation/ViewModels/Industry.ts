module InsuredApp {
    export module ViewModels {
        export module Organisation {
            export class Industry {
                Id: Core.Identifier;
                Code: string;
                Description: string;
                static Create(id: number, code: string, description: string) {
                    var result = new Industry();
                    result.Id = new Core.Identifier(id);
                    result.Code = code;
                    result.Description = description;
                    return result;
                }
            }
        }
    }
} 