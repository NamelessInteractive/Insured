namespace NamelessInteractive.Insured.Web.Controllers.Api.Branch

open NamelessInteractive.Insured.Web.Controllers.Api
open NamelessInteractive.Insured.Contracts.DataAccess.Branch
open NamelessInteractive.Insured.Domain.Branch

type BranchController() =
    inherit ApiControllerBase()
    let branchQueries = 
        {
            BranchQueries.GetBranches = NamelessInteractive.Insured.Data.Branch.GetBranches
        }
    member this.Get() : Branch seq =
        branchQueries.GetBranches()