module StringLibrary

open System

let union left right =
    left
    |> List.append right
    |> Seq.distinctBy (fun x -> fst x)
    |> List.ofSeq

let toDictionary (inputText: string) =
    let rec toDict = function
    | [] -> []
    | first::rest ->
            let sHead : string = first
            match sHead.Split ('=', StringSplitOptions.TrimEntries) with
            | [|""; _|] -> raise <| new ArgumentException()
            | [|a; b|] -> union [(a, b)] (toDict(rest))
            | [|a; ""; b|] -> (a, $"={b}")::toDict(rest)
            | _ -> []

    inputText.Split(';', StringSplitOptions.RemoveEmptyEntries)
    |> List.ofArray
    |> toDict
    |> List.rev