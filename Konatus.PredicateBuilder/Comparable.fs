namespace Konatus

open System

module Comparable =

    let Not (value: bool) : bool =
        not value

    let IsEquals (c1: IComparable) (c2: IComparable): bool =
        c1.CompareTo(c2) = 0

    let IsBefore (c1: IComparable) (c2: IComparable): bool =
        c1.CompareTo(c2) = -1

    let IsAfter (c1: IComparable) (c2: IComparable): bool =
        c1.CompareTo(c2) = 1

    let IsBeforeOrEquals (c1: IComparable) (c2: IComparable): bool =
        IsBefore c1 c2 || IsEquals c1 c2

    let IsAfterOrEquals (c1: IComparable) (c2: IComparable): bool =
        IsAfter c1 c2 || IsEquals c1 c2