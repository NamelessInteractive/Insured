[<AutoOpen>]
module NamelessInteractive.Insured.Data.ReadFunctions

open System.Data
open System

/// <summary>
/// Reads a String from a SqlDataReader
/// </summary>
/// <param name="fieldName">The name of the field to read</param>
/// <param name="reader">The data reader to read from</param>
let ReadString (fieldName: string) (reader:IDataReader) =
    let field= reader.GetOrdinal(fieldName)
    if (reader.IsDBNull(field)) then
        null
    else
        reader.GetString(reader.GetOrdinal(fieldName)).Trim()

/// <summary>
/// Reads a Decimal from a SqlDataReader
/// </summary>
/// <param name="fieldName">The name of the field to read</param>
/// <param name="reader">The data reader to read from</param>
let ReadDecimal (fieldName: string) (reader:IDataReader) =
    reader.GetDecimal(reader.GetOrdinal(fieldName))

/// <summary>
/// Reads a DateTimeOffset from a SqlDataReader
/// </summary>
/// <param name="fieldName">The name of the field to read</param>
/// <param name="reader">The data reader to read from</param>
let ReadDateTimeOffset (fieldName: string) (reader:IDataReader) =
    reader.GetValue(reader.GetOrdinal(fieldName)) :?> DateTimeOffset

let ReadDateTime (fieldName: string) (reader:IDataReader) =
    reader.GetDateTime(reader.GetOrdinal(fieldName)) 

let ReadDateTimeOffsetNull (fieldName: string) (reader:IDataReader) =
    let column = reader.GetOrdinal(fieldName)
    if (reader.IsDBNull(column)) then
        None
    else
        Some(reader.GetValue(column) :?> DateTimeOffset)

let ReadDate (fieldName: string) (reader:IDataReader) =
    reader.GetValue(reader.GetOrdinal(fieldName)) :?> DateTime

let ReadDateNull (fieldName: string) (reader:IDataReader) =
    let column = reader.GetOrdinal(fieldName)
    if (reader.IsDBNull(column)) then
        None
    else
        Some(reader.GetValue(column) :?> DateTime)

/// <summary>
/// Reads an Integer (32 bit) from a SqlDataReader
/// </summary>
/// <param name="fieldName">The name of the field to read</param>
/// <param name="reader">The data reader to read from</param>
let ReadInt (fieldName: string) (reader:IDataReader) =
    reader.GetInt32(reader.GetOrdinal(fieldName))

let ReadBigInt (fieldName: string) (reader:IDataReader) =
    reader.GetInt64(reader.GetOrdinal(fieldName))

let ReadIntNull (fieldName: string) (reader: IDataReader) =
    let column = reader.GetOrdinal(fieldName)
    if reader.IsDBNull(column) then
        None
    else
        Some(reader.GetInt32(column))

let ReadGuidNotNull (fieldName: string) (reader: IDataReader) =
    let column = reader.GetOrdinal(fieldName)
    (reader.GetGuid(column))

/// <summary>
/// Reads an Boolean from a SqlDataReader
/// </summary>
/// <param name="fieldName">The name of the field to read</param>
/// <param name="reader">The data reader to read from</param>
let ReadBool (fieldName: string) (reader:IDataReader) =
    let ordinal = reader.GetOrdinal(fieldName)
    let fieldType = reader.GetFieldType(ordinal)
    match fieldType.Name with
    | "Boolean" -> reader.GetBoolean(ordinal)
    | "Byte" -> match reader.GetByte(reader.GetOrdinal(fieldName)) with
                | 0uy -> false
                | _ -> true
    | _ -> raise (Exception(sprintf "No valid cast from %s to %s" fieldType.Name "Boolean"))

let ReadOption (fieldName: string) parseFunc (reader: IDataReader) =
    match reader.IsDBNull(fieldName) with
    | true -> None
    | false -> reader |> parseFunc |> Some