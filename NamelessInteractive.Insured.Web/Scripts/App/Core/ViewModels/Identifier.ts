module InsuredApp {
    export module ViewModels {
        export class Identifier {
            Identifier: number;
            constructor(identifier: number) {
                this.Identifier = identifier;
            }

            static Parse(value: any) {
                return new Identifier(value.Fields[0]);
            }
        }
    }
}