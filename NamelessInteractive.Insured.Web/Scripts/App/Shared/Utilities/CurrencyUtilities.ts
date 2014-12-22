module InsuredApp {
    export module Utilities {
        export module Shared {
            export class CurrencyUtilities {
                static FormatCurrency(value) {
                    if (value == null || value == undefined || value=="") {
                        return "Unknown";
                    }
                    var
                        res, d, t, s, i, j, n: any = "" + value;

                    n = n.replace(/,/g, '');
                    d = '.'; t = ','; s = n < 0 ? "-" : "";
                    i = parseInt(n = Math.abs(+n || 0) + "").toFixed(2) + "";
                    j = (j = i.length) > 3 ? j % 3 : 0;
                    var res = s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t);
                    if (!value || value == 0) {
                        res = res.replace(/,/g, '');
                    }
                    return 'R' + res;
                }
            }
        }
    }
} 