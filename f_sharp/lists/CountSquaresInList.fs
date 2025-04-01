module CountSquaresInList

let countSquares list =
    list
    |> List.filter (fun x -> List.exists (fun y -> y * y = x) list)
    |> List.length