module TasksWithList
open ChurchList

// 1.9 Нахождение элементов, расположенных перед последним минимальным
let elementsBeforeLastMin list =
    let rec findLastMinIndex lst currentIdx lastMinIdx currentMin =
        match lst with
        | [] -> lastMinIdx
        | head :: tail ->
            if head <= currentMin then
                findLastMinIndex tail (currentIdx + 1) currentIdx head
            else
                findLastMinIndex tail (currentIdx + 1) lastMinIdx currentMin

    let rec takeElements lst count acc =
        match lst with
        | [] -> List.rev acc
        | head :: tail ->
            if count > 0 then
                takeElements tail (count - 1) (head :: acc)
            else
                List.rev acc

    if List.isEmpty list then
        []
    else
        let minVal = List.min list
        let lastIdx = findLastMinIndex list 0 0 minVal
        takeElements list lastIdx []

let elementsBeforeLastMinList list =
    let minVal = List.min list
    let lastMinIndex = List.findIndexBack (fun x -> x = minVal) list
    list |> List.take lastMinIndex

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

// 1.49 Найти все уникальные простые делители элементов списка
let uniquePrimeDivisors list =
    let rec isPrime n divisor =
        if n <= 1 then false
        elif divisor * divisor > n then true
        elif n % divisor = 0 then false
        else isPrime n (divisor + 1)

    let rec getPrimeDivisors n divisor acc =
        if divisor > n then acc
        elif n % divisor = 0 && isPrime divisor 2 then
            getPrimeDivisors n (divisor + 1) (acc @ [divisor])
        else
            getPrimeDivisors n (divisor + 1) acc

    let rec collectPrimeDivisors list acc =
        match list with
        | [] -> acc
        | head :: tail ->
            let divisors = getPrimeDivisors head 2 []
            collectPrimeDivisors tail (acc @ divisors)

    let rec contains list elem =
        match list with
        | [] -> false
        | head :: tail ->
            if head = elem then true
            else contains tail elem

    let rec removeDuplicates list unique =
        match list with
        | [] -> unique
        | head :: tail ->
            if contains unique head then
                removeDuplicates tail unique
            else
                removeDuplicates tail (unique @ [head])

    let allDivisors = collectPrimeDivisors list []
    removeDuplicates allDivisors []

let uniquePrimeDivisorsList list =
    let isPrimeList n =
        n > 1 && [2..n-1] |> List.forall (fun x -> n % x <> 0)

    let primeDivisorsList n =
        [2..n] |> List.filter (fun x -> n % x = 0 && isPrimeList x)
    
    list |> List.collect primeDivisorsList |> Set.ofList |> Set.toList

// 1.59 Построить список квадратов неотрицательных чисел < 100, встречающихся > 2 раз
let squaresOfFrequentElements list =
    let rec countOccurrences elem list count =
        match list with
        | [] -> count
        | head :: tail ->
            if head = elem then
                countOccurrences elem tail (count + 1)
            else
                countOccurrences elem tail count

    let rec countAllElements list counted =
        match list with
        | [] -> counted
        | head :: tail ->
            if List.exists (fun (x, _) -> x = head) counted then
                countAllElements tail counted
            else
                let count = countOccurrences head list 0
                countAllElements tail (counted @ [(head, count)])

    let rec filterFrequent list filtered =
        match list with
        | [] -> filtered
        | (x, count) :: tail ->
            if x >= 0 && x < 100 && count > 2 then
                filterFrequent tail (filtered @ [x])
            else
                filterFrequent tail filtered

    let rec squareElements list squared =
        match list with
        | [] -> squared
        | head :: tail ->
            squareElements tail (squared @ [head * head])

    let counted = countAllElements list []
    let frequent = filterFrequent counted []
    squareElements frequent []

let squaresOfFrequentElementsList list =
    list
    |> List.countBy id
    |> List.filter (fun (x, count) -> x >= 0 && x < 100 && count > 2)
    |> List.map (fun (x, _) -> x * x)
