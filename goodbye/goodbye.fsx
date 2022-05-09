#load ".paket/load/net6.0/main.group.fsx"

open FSharp.Data
open System
open System.IO

let print y text = $"{y} - {text}"

let rec run = function
    | [] -> []
    | year::rest ->
        match year with
        | 2008 -> print year "start at Siemens Audiologische Technik"   :: run(rest)
        | 2012 -> print year "Cxx 7.0 release"                          :: run(rest)
        | 2013 -> print year "Time for Slimfast and a lighweight HI"    :: run(rest)
        | 2014 -> print year "Products Products Products must be funny" :: run(rest)
        | 2016 -> print year "Platform abstraction Layer D10"           :: run(rest)
        | 2017 -> print year "The Fellowship of FAPI and D11"           :: run(rest)
        | 2018 -> print year "Nexus it's not a google Smartphone"       :: run(rest)
        | 2019 -> print year "Pipe cleaned and ready for FitXP"         :: run(rest)
        | 2022 -> print year "FitXP"                                    :: run([42])
        | 42 -> ["-=[The End]=-"]
        | _ -> run(rest)

run [2008..2022] |> List.iter (fun s -> printfn "%s" s)