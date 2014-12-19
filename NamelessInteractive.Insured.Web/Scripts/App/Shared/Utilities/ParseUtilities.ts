module InsuredApp {
    export module Utilities {
        export module Shared {
            export class ParseUtilities {
                static IfNull(nullTestValue, value, defaultValue) {
                    if (nullTestValue == null || nullTestValue == undefined) {
                        return defaultValue;
                    }
                    else {
                        return value;
                    }
                }
            }
        }
    }
} 