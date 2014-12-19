module InsuredApp {
    export module ViewModels {
        export module Organisation {
            export class Director {
                Id: Core.Identifier;
                Validity: Shared.ValidityInformation;
                Party: Party.Party;
            }
        }
    }
}