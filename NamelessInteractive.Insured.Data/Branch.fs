module NamelessInteractive.Insured.Data.Branch

open NamelessInteractive.Insured.Domain.Branch

let ParseBranch reader : Branch =
    {
        Branch.Id = reader |> ReadInt "BranchId" |> ParseId
        Code = reader |> ReadString "BranchCode"
        Description = reader |> ReadString "BranchDesc"
        Address = 
            match Address.GetAddressById(reader |> ReadInt "AddressId") with
            | None -> failwith "Branch %s doesn't have an address" (reader |> ReadString "BranchCode")
            | Some address -> address
    }

let GetBranches() =
    ExecuteReaderWithConnectionString
        LogicalModelConnectionStringName
        "Select * From Branch"
        []
        ParseBranch
    
