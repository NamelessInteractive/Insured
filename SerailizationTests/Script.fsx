// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.
#r @"C:\Development\Github\NamelessInteractive.Insured\packages\Newtonsoft.Json.6.0.6\lib\net45\Newtonsoft.Json.dll"
#r @"C:\Development\Github\NamelessInteractive.Insured\NamelessInteractive.Insured.Domain\bin\Debug\NamelessInteractive.Insured.Domain.dll"
#r @"C:\Development\Github\NamelessInteractive.Insured\NamelessInteractive.Insured.Infrastructure\bin\Debug\NamelessInteractive.Insured.Infrastructure.dll"
type SCase = SCase of SCase: int
type CType = 
    {
        Value: int option
        MyCase: SCase
    }
let test = { Value = None; MyCase = SCase(1) }
open Newtonsoft.Json
open NamelessInteractive.Insured.Infrastructure.Serializers
JsonConvert.DefaultSettings <- fun _ -> JsonSerializerSettings(Converters=[|OptionConverter(); SingleCaseDUConverter()|])
let ser = JsonConvert.SerializeObject(test)
let des = JsonConvert.DeserializeObject<CType>(ser)

