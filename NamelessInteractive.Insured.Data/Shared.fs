[<AutoOpen>]
module NamelessInteractive.Insured.Data.Shared

open NamelessInteractive.Insured.Domain.Shared
open System.Data.SqlClient
open System

let LogicalModelConnectionStringName = "LogicalModel"
let GetConnectionString(connectionStringName: string) = 
    System.Configuration.ConfigurationManager.ConnectionStrings.[connectionStringName].ConnectionString

let GetConnection(connectionStringName) =
    let connectionString = GetConnectionString(connectionStringName)
    let connection = new System.Data.SqlClient.SqlConnection(connectionString)
    connection.Open()
    connection

let AddParameterToCommand  (command: SqlCommand) (parameter: string*obj) =
    let paramValue = snd parameter
    if (paramValue = null) then
        command.Parameters.AddWithValue(fst parameter, DBNull.Value) |> ignore
    else
        command.Parameters.AddWithValue(fst parameter, paramValue) |> ignore

let AddParametersToCommand (parameters: (string * obj) seq) (command:SqlCommand) =
    if (not (Seq.isEmpty(parameters))) then
        parameters |> Seq.iter (AddParameterToCommand command)

let ExecuteReaderWithConnectionString<'T> connectionStringName commandText (parameters: (string * obj) seq) readFunc = 
    use connection = GetConnection(connectionStringName)
    use command = new System.Data.SqlClient.SqlCommand(commandText, connection)
    command |> AddParametersToCommand parameters
    command.CommandTimeout <- 0
    use reader = command.ExecuteReader()
    let result = new ResizeArray<'T>()
    while reader.Read() do
        result.Add(reader |> readFunc)
    result :> 'T seq

let ExecuteRowWithConnectionString<'T> connectionStringName commandText (parameters: (string * obj) seq) readFunc = 
    use connection = GetConnection(connectionStringName)
    use command = new System.Data.SqlClient.SqlCommand(commandText, connection)
    command |> AddParametersToCommand parameters
    command.CommandTimeout <- 0
    use reader = command.ExecuteReader()
    let result = new ResizeArray<'T>()
    while reader.Read() do
        result.Add(reader |> readFunc)
    match result.Count > 0 with
    | true -> result |> Seq.head |> Some
    | false -> None

let ParseId (id:int) = Identifier(id)

type System.Data.IDataReader with
    member this.IsDBNull(column) =
        this.IsDBNull(this.GetOrdinal(column))