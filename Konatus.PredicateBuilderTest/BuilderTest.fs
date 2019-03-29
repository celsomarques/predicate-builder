module PredicateBuilder

open System
open Xunit
open Konatus

[<Fact>]
let ``And(false) - should return false`` () =
    PredicateBuilder().
        And(false).
        Value() |> Assert.False

[<Fact>]
let ``And(false).And(true) - should return false`` () =
    PredicateBuilder().
        And(false).
        And(true).
        Value() |> Assert.False

[<Fact>]
let ``And(true) - should return true`` () =
    PredicateBuilder().
        And(true).
        Value() |> Assert.True

[<Fact>]
let ``And(true).And(true) - should return true`` () =
    PredicateBuilder().
        And(true).
        And(true).
        Value() |> Assert.True

[<Fact>]
let ``Or(false) - should return false`` () =
    PredicateBuilder().
        Or(false).
        Value() |> Assert.False

[<Fact>]
let ``Or(false, false) - should return false`` () =
    PredicateBuilder().
        Or(false, false).
        Value() |> Assert.False

[<Fact>]
let ``Or(false, true) - should return true`` () =
    PredicateBuilder().
        Or(false, true).
        Value() |> Assert.True

[<Fact>]
let ``Or(false, true).And(true) - should return true`` () =
    PredicateBuilder().
        Or(false, true).
        And(true).
        Value() |> Assert.True

[<Fact>]
let ``Or(false, true).And(false) - should return false`` () =
    PredicateBuilder().
        Or(false, true).
        And(false).
        Value() |> Assert.False

[<Fact>]
let ``And(true).And(Or(false, true)) - should return true`` () =
    PredicateBuilder().
        And(true).
        And(
            PredicateBuilder.Or(false, true)
        ).
        Value() |> Assert.True

[<Fact>]
let ``And(true).And(Or(false, false)) - should return false`` () =
    PredicateBuilder().
        And(true).
        And(
            PredicateBuilder.Or(false, false)
        ).
        Value() |> Assert.False

[<Fact>]
let ``And(false).And(Or(false, true)) - should return false`` () =
    PredicateBuilder().
        And(false).
        And(
            PredicateBuilder.Or(false, true)
        ).
        Value() |> Assert.False

[<Fact>]
let ``PredicateBuilder.Or(false, false)) - should return false`` () =
    PredicateBuilder.Or(false, false) |> Assert.False

[<Fact>]
let ``PredicateBuilder.Or(true, false)) - should return true`` () =
    PredicateBuilder.Or(true, false) |> Assert.True