[![Build status](https://ci.appveyor.com/api/projects/status/tp317tsmd1myo32v/branch/master?svg=true)](https://ci.appveyor.com/project/celsomarques/predicate-builder/branch/master)


# Predicate Builder

Predicate Builder is a simple tool to make your code cleaner and more readable. It was written in F# and use _mutable_ list that holds boolean values in order to provide DSL to C#. 
There are some functions to simplify comparisons in order to improve readability, as follows:

## Comparable

* Not(value: bool): bool
* IsEquals(c1: IComparable, c2: IComparable): bool
* IsBefore(c1: IComparable, c2: IComparable): bool
* IsAfter(c1: IComparable, c2: IComparable): bool
* IsBeforeOrEquals(c1: IComparable, c2: IComparable): bool
* IsAfterOrEquals(c1: IComparable, c2: IComparable): bool

## PredicateBuilder

* And(value: bool): PredicateBuilder
* Or(value: bool): PredicateBuilder
* static Or(value: bool): bool
* Value(): bool

### Usage in C# code

```
using Konatus;
using static Konatus.PredicateBuilder;
using static Konatus.Comparable;

(...)
public Func<Table, bool> Filter(object someObj) {
    return = p => new PredicateBuilder().
        And(IsEquals(p.ID, someObj.FOREIGN_ID.Value)).
        And(IsBeforeOrEquals(p.START_DATE.Date, someObj.START_TIME.Value.Date)).
        And(
            Or(
                IsAfterOrEquals(p.END_DATE.Value.Date, someObj.END_TIME.Value.Date),
                Not(p.HasEndDate())
            )
        ).
        Value();
}
(...)

```
