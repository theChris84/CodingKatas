module ToDicitionaryShould

open System
open Xunit
open FsUnit.Xunit
open StringLibrary

let inputDataSet: seq<array<Object>> =
    seq {
        yield [|"a=1;b=2;c=3"; [("a", "1"); ("b", "2"); ("c", "3") ]|]
        yield [|"a=1;b=2"; [("a", "1"); ("b", "2")]|]
        yield [|"a=1;;b=2"; [("a", "1"); ("b", "2")]|]
        yield [|"a="; [("a", "")]|]
        yield [|"a==1"; [("a", "=1")]|]
        yield [| "a = 1;;c = ;;b = = 2"; [("a","1");("c","");("b","=2")]|] //end game
    }

[<Theory>]
[<MemberData(nameof(inputDataSet))>]
let ``Intput can split by semicolon and equal symbol`` (input, expected) =
    toDictionary input |> should equal expected

[<Fact>]
let ``Return empty list on empty input`` () =
    toDictionary "" |> should be Empty

[<Fact>]
let ``Received exception on invalid input`` () =
    (fun () -> toDictionary "=1" |> ignore) |> should throw typeof<ArgumentException>