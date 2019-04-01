module Comparable

open System
open Xunit
open Konatus

[<Fact>]
let ``Not(true) - Should return false`` () =
    Comparable.Not true |> Assert.False

[<Fact>]
let ``Not(false) - Should return true`` () =
    Comparable.Not false |> Assert.True

[<Fact>]
let ``IsEquals(1, 1) - Should return true`` () =
    Comparable.IsEquals 1 1 |> Assert.True

[<Fact>]
let ``IsEquals(0, 1) - Should return false`` () =
    Comparable.IsEquals 0 1 |> Assert.False

[<Fact>]
let ``IsEquals("test", "Test") - Should return false`` () =
    Comparable.IsEquals "test" "Test" |> Assert.False

[<Fact>]
let ``IsEquals("test", "test") - Should return true`` () =
    Comparable.IsEquals "test" "test" |> Assert.True

[<Fact>]
let ``IsBefore(0, 1) - Should return true`` () =
    Comparable.IsBefore 0 1 |> Assert.True 

[<Fact>]
let ``IsBefore(1, 0) - Should return false`` () =
    Comparable.IsBefore 1 0 |> Assert.False

[<Fact>]
let ``IsAfter(1, 0) - Should return true`` () =
    Comparable.IsAfter 1 0 |> Assert.True
    
[<Fact>]
let ``IsAfter(0, 1) - Should return false`` () =
    Comparable.IsAfter 0 1 |> Assert.False 

[<Fact>]
let ``IsBeforeOrEquals(1, 0) - Should return false`` () =
    Comparable.IsBeforeOrEquals 1 0 |> Assert.False 

[<Fact>]
let ``IsBeforeOrEquals(0, 1) - Should return true`` () =
    Comparable.IsBeforeOrEquals 0 1 |> Assert.True 

[<Fact>]
let ``IsBeforeOrEquals(1, 1) - Should return true`` () =
    Comparable.IsBeforeOrEquals 1 1 |> Assert.True 

[<Fact>]
let ``IsAfterOrEquals(0, 1) - Should return false`` () =
    Comparable.IsAfterOrEquals 0 1 |> Assert.False 

[<Fact>]
let ``IsAfterOrEquals(1, 0) - Should return true`` () =
    Comparable.IsAfterOrEquals 1 0 |> Assert.True 

[<Fact>]
let ``IsAfterOrEquals(1, 1) - Should return true`` () =
    Comparable.IsAfterOrEquals 1 1 |> Assert.True