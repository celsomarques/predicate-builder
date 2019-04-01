namespace Konatus

open System

type Comparable =

    static member Not (value: bool) : bool =
        not value

    static member IsEquals (c1: Nullable<_>, c2: Nullable<_>): bool =
        Nullable.Compare(c1, c2) = 0

    static member IsEquals (c1: IComparable, c2: IComparable): bool =
        c1.CompareTo(c2) = 0

    static member IsBefore (c1: Nullable<_>, c2: Nullable<_>): bool =
        Nullable.Compare(c1, c2) = -1

    static member IsBefore (c1: IComparable, c2: IComparable): bool =
        c1.CompareTo(c2) = -1

    static member IsAfter (c1: Nullable<_>, c2: Nullable<_>): bool =
        Nullable.Compare(c1, c2) = 1

    static member IsAfter (c1: IComparable, c2: IComparable): bool =
        c1.CompareTo(c2) = 1

    static member IsBeforeOrEquals (c1: Nullable<_>, c2: Nullable<_>): bool =
        Comparable.IsBefore(c1, c2) || Comparable.IsEquals(c1, c2)

    static member IsBeforeOrEquals (c1: IComparable, c2: IComparable): bool =
        Comparable.IsBefore(c1, c2) || Comparable.IsEquals(c1, c2)

    static member IsAfterOrEquals (c1: Nullable<_>, c2: Nullable<_>): bool =
        Comparable.IsAfter(c1, c2) || Comparable.IsEquals(c1, c2)

    static member IsAfterOrEquals (c1: IComparable, c2: IComparable): bool =
        Comparable.IsAfter(c1, c2) || Comparable.IsEquals(c1, c2)