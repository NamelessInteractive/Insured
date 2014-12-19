module InsuredApp {
    export module ViewModels {
        export module Core {

            export class Identifier {
                Identifier: number;
                constructor(identifier: number) {
                    this.Identifier = identifier;
                }

                toString() {
                    return this.Identifier;
                }

                static Parse(value: any) {
                    return new Identifier(value.Fields[0]);
                }
            }
        }
    }
}