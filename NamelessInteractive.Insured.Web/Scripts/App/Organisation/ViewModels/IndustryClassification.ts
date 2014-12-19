module InsuredApp {
    export module ViewModels {
        export module Organisation {
            export class IndustryClassification {
                Id: Core.Identifier;
                Code: string;
                Description: string;
                Category: string;
                IndustryCode: string;
                static Create(id: number, code: string, description: string, category: string, industryCode: string) {
                    var result = new IndustryClassification();
                    result.Id = new Core.Identifier(id);
                    result.Code = code;
                    result.Description = description;
                    result.Category = category;
                    result.IndustryCode = industryCode;
                    return result;
                }
            }
        }
    }
} 