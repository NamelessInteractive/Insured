#if INTERACTIVE
#r @"C:\Development\Github\NamelessInteractive.Insured\packages\Newtonsoft.Json.6.0.6\lib\net45\Newtonsoft.Json.dll"
#r @"C:\Development\Github\NamelessInteractive.Insured\NamelessInteractive.Insured.Domain\bin\Debug\NamelessInteractive.Insured.Domain.dll"
#r @"C:\Development\Github\NamelessInteractive.Insured\NamelessInteractive.Insured.Infrastructure\bin\Debug\NamelessInteractive.Insured.Infrastructure.dll"    
#endif 
open Newtonsoft.Json

type Inner =
    {
        AValue: string
    }
type SCase = SCase of FV1: int * FV2 : Inner option
type CType = 
    {
        Value: int option
        MyCase: SCase option
    }
let test = { Value = None; MyCase = Some( SCase(1,Some{ AValue ="Hello"})) }
open Newtonsoft.Json
open NamelessInteractive.Insured.Infrastructure.Serializers
JsonConvert.DefaultSettings <- fun _ -> JsonSerializerSettings(Converters=[|OptionConverter(); SingleCaseDUConverter()|])
let ser = JsonConvert.SerializeObject(test)
printfn "%s" ser
let des = JsonConvert.DeserializeObject<CType>(ser)
printfn "%A" (des = test)
System.Console.ReadLine() |> ignore

