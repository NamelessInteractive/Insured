﻿namespace NamelessInteractive.Insured.Web.Controllers.Mvc

open System.Web.Mvc

type OrganisationController() =
    inherit SimpleViewController()
    member this.Test() = this.PartialView()
