module StringLibrary

open System

let toDictionary (value: string) =
    let rec toDict = function 
    | [] -> []
    | head::tail -> 
            let sHead : string = head
            match sHead.Split '=' with
            | [|""; _|] -> raise <| new ArgumentException()
            | [||] -> toDict(tail)
            | [|a|] -> (a, "")::toDict(tail)
            | [|a; b|] -> (a, b)::toDict(tail)
            | [|a; ""; b|] -> (a, $"={b}")::toDict(tail)
            | _ -> []

    let i = value.Split(';', StringSplitOptions.RemoveEmptyEntries) |> List.ofArray
    toDict i 