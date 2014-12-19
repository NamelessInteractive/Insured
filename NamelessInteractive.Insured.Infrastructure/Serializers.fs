namespace NamelessInteractive.Insured.Infrastructure.Serializers

open Newtonsoft.Json
open Microsoft.FSharp.Reflection
open Newtonsoft.Json.Linq

type OptionConverter() = 
    inherit JsonConverter()
    override this.CanConvert(objectType) =
        let result = objectType.IsGenericType && objectType.GetGenericTypeDefinition() = typedefof<option<_>>
        result
    override this.WriteJson(writer,value,serializer) =
        let value = 
            if (value = null) then null
            else
                let _, fields = FSharpValue.GetUnionFields(value,value.GetType())
                fields.[0]
        serializer.Serialize(writer,value)

    override this.ReadJson(reader,objectType,existingValue,serializer) =
        let innerType = objectType.GetGenericArguments().[0]
        let innerType = 
            if innerType.IsValueType then typedefof<System.Nullable<_>>.MakeGenericType([|innerType|])
            else innerType
        let value = serializer.Deserialize(reader,innerType)
        let cases = FSharpType.GetUnionCases(objectType)
        if value = null then FSharpValue.MakeUnion(cases.[0], [||])
        else FSharpValue.MakeUnion(cases.[1],[|value|])

type SingleCaseDUConverter() =
    inherit JsonConverter()
    override this.CanConvert(objectType) =
        FSharpType.IsUnion(objectType) && FSharpType.GetUnionCases(objectType).Length = 1
    override this.WriteJson(writer,value,serializer)  =
        let objectType = value.GetType()
        let caseInfo, fieldValues = FSharpValue.GetUnionFields(value,objectType)
        writer.WriteStartObject()
        let fields = caseInfo.GetFields()
        for i in 0 .. fields.Length - 1 do 
            let field = fields.[i]
            writer.WritePropertyName(field.Name)
            serializer.Serialize(writer,fieldValues.[i])
        writer.WriteEndObject()

    override this.ReadJson(reader,objectType,_ ,serializer) =
        let jo = JObject.Load(reader)        
        let caseInfo = FSharpType.GetUnionCases(objectType) |> Seq.head
        let fields = caseInfo.GetFields()
        let res = System.Collections.Generic.Dictionary<string, obj>()
        for i in 0 .. fields.Length - 1 do
            let field = fields.[i]
            let name = field.Name
            let value =
                match field.PropertyType with
                | x when x.Name = "String" -> box (jo.[name].ToString())
                | _ -> JsonConvert.DeserializeObject(jo.[name].ToString(),field.PropertyType)
            res.Add(name,value)
        let fRes = res |> Seq.map(fun r->r.Value) |> Array.ofSeq
        FSharpValue.MakeUnion(caseInfo,fRes)

            
            

        
            
            
            
        

    
