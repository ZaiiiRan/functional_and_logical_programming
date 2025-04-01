module TasksWithList
open ChurchList

// 1.19 Циклический сдвиг вправо
let shiftRight list =
    match list with
    | [] -> []
    | [x] -> [x]
    | _ -> 
        let rec getLastAndInit lst =
            match lst with
            | [] -> failwith "Пустой список"
            | [x] -> (x, [])
            | h :: t -> 
                let (last, init) = getLastAndInit t
                (last, h :: init)
        let (last, init) = getLastAndInit list
        last :: init

let shiftRightList list =
    match List.rev list with
    | [] -> []
    | last :: rest -> last :: List.rev rest

// 1.29 Проверка наличия максимального элемента в интервале [a..b]
let containsMaxInRange list a b =
    let rec checkMaxInRange list maxEl =
        match list with
        | [] -> false
        | head :: tail ->
            if head = maxEl && head >= a && head <= b then true
            else checkMaxInRange tail maxEl
    let maxEl = ChurchList.maxList list
    checkMaxInRange list maxEl

let containsMaxInRangeList list a b =
    let maxEl = List.max list
    list |> List.exists (fun x -> x = maxEl && x >= a && x <= b)

// 1.39 Вывести сначала элементы с четными индексами, затем с нечетными
let evenThenOdd list =
    let rec splitEvenOdd list index evens odds =
        match list with
        | [] -> (evens, odds)
        | head :: tail ->
            if index % 2 = 0 then
                splitEvenOdd tail (index + 1) (evens @ [head]) odds
            else
                splitEvenOdd tail (index + 1) evens (odds @ [head])

    let evens, odds = splitEvenOdd list 0 [] []
    evens @ odds

let evenThenOddList list =
    let evens = list |> List.mapi (fun i x -> if i % 2 = 0 then Some x else None) |> List.choose id
    let odds = list |> List.mapi (fun i x -> if i % 2 <> 0 then Some x else None) |> List.choose id
    evens @ odds
