module StringLibrary

open System

let toDictionary (inputText: string) =
    let rec toDict = function
    | [] -> []
    | head::tail ->
            let sHead : string = head
            match sHead.Split '=' with
            | [|""; _|] -> raise <| new ArgumentException()
            | [|a; b|] -> (a, b)::toDict(tail)
            | [|a; ""; b|] -> (a, $"={b}")::toDict(tail)
            | _ -> []

    inputText.Split(';', StringSplitOptions.RemoveEmptyEntries)
    |> List.ofArray
    |> toDict