namespace Konatus

open System
open System.Linq

module Predicate =

    type Comparable() =

        static member IsEquals (c1: IComparable) (c2: IComparable): bool =
            c1.CompareTo(c2) = 0

        static member IsBefore (c1: IComparable) (c2: IComparable): bool =
            c1.CompareTo(c2) = -1

        static member IsAfter (c1: IComparable) (c2: IComparable): bool =
            c1.CompareTo(c2) = 1

        static member IsBeforeOrEquals (c1: IComparable) (c2: IComparable): bool =
            Comparable.IsBefore c1 c2 || Comparable.IsEquals c1 c2

        static member IsAfterOrEquals (c1: IComparable) (c2: IComparable): bool =
            Comparable.IsAfter c1 c2 || Comparable.IsEquals c1 c2

    type Builder() =
        inherit Comparable()

        let mutable list: List<bool> = []

        member this.And value =
            list <- list @ [ value ]
            this

        member this.Or([<ParamArray>] values: bool[]) =
            list <- list @ [ Builder.Or(values) ]
            this

        static member Or([<ParamArray>] values: bool[]) =
            values.Any (fun v -> v = true)

        member this.Value =
            list.All (fun v -> v = true)
