﻿namespace NamelessInteractive.Insured.Web.Controllers.Mvc

open System.Web.Mvc

type IndividualController() =
    inherit SimpleViewController()
    member this.Test() = this.PartialView()
