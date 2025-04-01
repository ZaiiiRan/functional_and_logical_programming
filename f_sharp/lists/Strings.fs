module Strings
open System
open System.Linq

let isLatinLettersPalindrome (str: string) =
    let latinLetters = 
        str.ToLowerInvariant()
            .Where(fun c -> Char.IsLetter(c) && c >= 'a' && c <= 'z')
            .ToArray()
    Enumerable.SequenceEqual(latinLetters, latinLetters.Reverse())

let calculateDeviation (str: string) =
    if String.IsNullOrEmpty(str) then 0.0
    else
        let maxAscii = str |> Seq.map int |> Seq.max |> float
        
        let mirrorPairs =
            let n = str.Length
            [0..n/2-1] 
            |> List.map (fun i -> (str.[i], str.[n-1-i]))
        
        let diffs = 
            mirrorPairs 
            |> List.map (fun (a,b) -> abs(int a - int b) |> float)
        
        let avgDiff = if diffs.IsEmpty then 0.0 else List.average diffs
        
        let squaredDeviations = 
            diffs 
            |> List.map (fun d -> (d - avgDiff) ** 2.0)
        
        if squaredDeviations.IsEmpty then 0.0
        else List.sum squaredDeviations

let sortStrings (strings: string list) =
    strings
    |> List.map (fun s -> (s, calculateDeviation s))
    |> List.sortBy snd
    |> List.map fst