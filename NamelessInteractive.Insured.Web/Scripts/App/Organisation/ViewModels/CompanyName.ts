module InsuredApp {
    export module ViewModels {
        export module Organisation {
            export class CompanyName {
                RegisteredName: string;
                TradingName: string;
                static Create(registeredName, tradingName) {
                    var result = new CompanyName();
                    result.RegisteredName = registeredName;
                    result.TradingName = tradingName;
                    return result;
                }
            }
        }
    }
} 