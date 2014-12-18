module InsuredApp {
    export module ViewModels {
        export module Organisation {
            export class CompanyName {
                RegisteredName: string;
                TradingName: string;
                
            }

            export class Organisation {
                Id: Identifier;
                CompanyName: CompanyName;
                static Test() {
                    var result = new Organisation();
                    result.Id = new Identifier(100);
                    result.CompanyName = new CompanyName();
                    result.CompanyName.TradingName = "Trading Company";
                    result.CompanyName.RegisteredName = "Registered Company";
                    return result;
                    
                }
            }
        }
    }
}