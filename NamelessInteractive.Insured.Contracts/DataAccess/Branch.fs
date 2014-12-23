module NamelessInteractive.Insured.Contracts.DataAccess.Branch

open NamelessInteractive.Insured.Domain.Branch

type GetBranches = unit -> Branch seq

type BranchQueries =
    {
        GetBranches: GetBranches
    }