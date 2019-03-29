module Builder

open System
open Xunit
open Konatus.Predicate

[<Fact>]
let ``And(false) - should return false`` () =
    Builder().
        And(false).
        Value |> Assert.False

[<Fact>]
let ``And(false).And(true) - should return false`` () =
    Builder().
        And(false).
        And(true).
        Value |> Assert.False

[<Fact>]
let ``And(true) - should return true`` () =
    Builder().
        And(true).
        Value |> Assert.True

[<Fact>]
let ``And(true).And(true) - should return true`` () =
    Builder().
        And(true).
        And(true).
        Value |> Assert.True

[<Fact>]
let ``Or(false) - should return false`` () =
    Builder().
        Or(false).
        Value |> Assert.False

[<Fact>]
let ``Or(false, false) - should return false`` () =
    Builder().
        Or(false, false).
        Value |> Assert.False

[<Fact>]
let ``Or(false, true) - should return true`` () =
    Builder().
        Or(false, true).
        Value |> Assert.True

[<Fact>]
let ``Or(false, true).And(true) - should return true`` () =
    Builder().
        Or(false, true).
        And(true).
        Value |> Assert.True

[<Fact>]
let ``Or(false, true).And(false) - should return false`` () =
    Builder().
        Or(false, true).
        And(false).
        Value |> Assert.False

[<Fact>]
let ``And(true).And(Or(false, true)) - should return true`` () =
    Builder().
        And(true).
        And(
            Builder.Or(false, true)
        ).
        Value |> Assert.True

[<Fact>]
let ``And(true).And(Or(false, true)) - should return false`` () =
    Builder().
        And(true).
        And(
            Builder.Or(false)
        ).
        Value |> Assert.False

[<Fact>]
let ``And(false).And(Or(false, true)) - should return false`` () =
    Builder().
        And(false).
        And(
            Builder.Or(false, true)
        ).
        Value |> Assert.False