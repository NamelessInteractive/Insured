module InsuredApp {
    export module ViewModels {
        export class Option<T> {
            private value: T;
            Case: string;
            Fields: Array<T>;
            static Some<T>(value: T) {
                var result = new Option<T>();
                result.Case = "Some";
                result.Fields = [value];
                return result;
            }

            static None() {
                var result = new Option();
                result.Case = "None";
                result.Fields = [];
                return result;
            }
        }
    }
}