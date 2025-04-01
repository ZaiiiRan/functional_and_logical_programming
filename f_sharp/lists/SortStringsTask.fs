module SortStringsTask
open System

let sortByLength (strings: string list) =
    strings |> List.sortBy String.length

let readStrings =
    let rec read acc =
        let input = Console.ReadLine()
        if input = "" then List.rev acc
        else read (input :: acc)
    read []