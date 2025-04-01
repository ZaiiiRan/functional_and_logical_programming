module CreateTuplesTask

let sumOfDigits n =
    n |> abs |> string |> Seq.sumBy (fun c -> int c - int '0')

let countDivisors n =
    let absN = abs n
    [1..absN] |> List.filter (fun x -> absN % x = 0) |> List.length

let customSort list keyFunc reverse =
    list |> List.sortBy (fun x -> keyFunc x, if reverse then -abs x else abs x)

let createTuples listA listB listC =
    let sortedA = List.sortDescending listA
    let sortedB = customSort listB sumOfDigits false
    let sortedC = customSort listC countDivisors true
    
    List.zip3 sortedA sortedB sortedC