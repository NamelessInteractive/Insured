namespace NamelessInteractive.Insured.Web.Controllers.Api

open System.Web.Http

type ValuesController() = 
    inherit ApiController()
    member this.Get() =
        [|"value1"; "value2"|]

    member this.Get(id: int) =
        "value"

    member this.Post([<FromBody>]value: string) =
        ()

    member this.Put(id: int, [<FromBody>]value: string) =
        ()

    member this.Delete(id: int) =
        ()
