namespace Konatus

open System
open System.Linq

type PredicateBuilder() =

    let mutable list: List<bool> = []

    member this.And value =
        list <- list @ [ value ]
        this

    member this.Or([<ParamArray>] values: bool[]) =
        list <- list @ [ PredicateBuilder.Or(values) ]
        this

    static member Or([<ParamArray>] values: bool[]) =
        values.Any (fun v -> v = true)

    member this.Value() =
        list.All (fun v -> v = true)