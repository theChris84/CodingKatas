module ToDicitionaryShould

open System
open Xunit
open StringLibrary

let inputDataSet: seq<array<Object>> =
    seq {
        yield [|
            "a=1;b=2;c=3"
            [("a", "1"); ("b", "2"); ("c", "3") ]
        |]
        yield [|
            "a=1;b=2"
            [("a", "1"); ("b", "2")]
        |] 
        yield [|
            "a=1;;b=2"
            [("a", "1"); ("b", "2")]
        |]
        yield [|
            "a="
            [("a", "")]
        |]
        yield [|
            "a==1"
            [("a", "=1")]
        |]
    }


[<Theory>]
[<MemberData(nameof(inputDataSet))>]
let ``Intput can split by semicolon and equal symbol`` (input, expected) =
    //arrange, act
    let result = toDictionary input
    //assert
    Assert.Equal<List<string*string>>(expected, result)

[<Fact>]
let ``Return empty list on empty input`` () =
    //arrange, act
    let result = toDictionary ""
    //assert
    Assert.Equal<List<string*string>>([], result)

[<Fact>]
let ``Received exception on invalid input`` () =
    //arrange, act, assert
    Assert.Throws<ArgumentException>( fun _ ->  toDictionary "=1" |> ignore )