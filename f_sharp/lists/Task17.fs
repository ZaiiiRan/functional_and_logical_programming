module Task17
open System

let readIntList () =
    printfn "Введите элементы списка через пробел:"
    let input = Console.ReadLine()
    try
        if String.IsNullOrWhiteSpace input then
            []
        else
            input.Split(' ')
            |> Array.filter (fun s -> not (String.IsNullOrWhiteSpace s))
            |> Array.map int
            |> List.ofArray
    with
    | :? FormatException ->
        []
    | ex ->
        []

let readInt () =
    printfn "Введите число:"
    try
        Console.ReadLine() |> int
    with
    | :? FormatException ->
        0

// 1 Наибольшая общая подпоследовательность
let longestCommonSubsequence (seq1: 'a list) (seq2: 'a list) =
    let rec lcs (s1: 'a list) (s2: 'a list) (memo: Map<int * int, 'a list>) =
        let key = (s1.Length, s2.Length)
        if memo.ContainsKey key then memo.[key]
        else
            match s1, s2 with
            | [], _ | _, [] -> []
            | x::xs, y::ys when x = y ->
                let sub = lcs xs ys memo
                x :: sub
            | x::xs, y::ys ->
                let left = lcs xs s2 memo
                let right = lcs s1 ys memo
                if left.Length > right.Length then left else right
    lcs seq1 seq2 Map.empty

// 2 Кортеж из пяти списков
let fiveLists (list: int list) =
    let list1 = list |> List.filter (fun x -> x % 2 = 0) |> List.map (fun x -> x / 2)
    let list2 = list1 |> List.filter (fun x -> x % 3 = 0) |> List.map (fun x -> x / 3)
    let list3 = list2 |> List.map (fun x -> x * x)
    let list4 = list3 |> List.filter (fun x -> List.contains x list1)
    let list5 = (list2 @ list3 @ list4) |> List.distinct
    (list1, list2, list3, list4, list5)

// 3 Список кортежей (a, b) для числа N
let factorPairs (n: int) =
    let gcd a b =
        let rec gcd' a b = if b = 0 then a else gcd' b (a % b)
        gcd' (abs a) (abs b)
    [1..int (sqrt (float n))]
    |> List.filter (fun d -> n % d = 0)
    |> List.collect (fun d ->
        let x = d
        let y = n / d
        let d' = gcd x y
        [(x / d', y / d')])
    |> List.distinct

// 4 Пифагоровы тройки
let pythagoreanTriples (list: int list) =
    let isPythagorean a b c = a * a + b * b = c * c
    list
    |> List.collect (fun a ->
        list
        |> List.filter (fun b -> b > a)
        |> List.collect (fun b ->
            list
            |> List.filter (fun c -> c > b && isPythagorean a b c)
            |> List.map (fun c -> (a, b, c))))
    |> List.distinct

// 5 Элементы с полным набором простых делителей
let primeFactors n =
    let rec factors n d acc =
        if n = 1 then acc
        else if n % d = 0 then factors (n / d) d (d :: acc)
        else factors n (d + 1) acc
    factors (abs n) 2 []

let allPrimeDivisorsPresent (list: int list) =
    let allPrimes = list |> List.collect primeFactors |> List.distinct
    list |> List.filter (fun x ->
        let xPrimes = primeFactors x |> List.distinct
        allPrimes |> List.forall (fun p -> List.contains p xPrimes))

// 6 Сортировка кортежей и преобразование в числа
let sortAndConvertTuples (list: (int * int * int * int * int) list) =
    list
    |> List.filter (fun (a, b, c, d, e) -> List.forall (fun x -> x >= 0 && x <= 9) [a; b; c; d; e])
    |> List.sort
    |> List.map (fun (a, b, c, d, e) -> a * 10000 + b * 1000 + c * 100 + d * 10 + e)

// 7 Упорядочивание по сумме делителей
let divisors n =
    [1..int (sqrt (float n))]
    |> List.filter (fun d -> n % d = 0)
    |> List.collect (fun d -> if d * d = n then [d] else [d; n / d])

let sortByDivisorsParam (list: int list) =
    let evenPos = list |> List.indexed |> List.filter (fun (i, _) -> i % 2 = 0) |> List.map snd
    let avg = float (List.sum list) / float (List.length list)
    let lessThanAvg = list |> List.filter (fun x -> float x < avg)
    let p a =
        divisors a
        |> List.filter (fun d -> evenPos |> List.exists (fun x -> x % d = 0))
        |> List.filter (fun d -> lessThanAvg |> List.forall (fun x -> x % d <> 0))
        |> List.sum
    list |> List.sortBy p

// 8 Среднее арифметическое популярных цифр
let digitFrequency (list: int list) =
    list
    |> List.collect (fun n -> string (abs n) |> Seq.map (fun c -> int c - int '0') |> List.ofSeq)
    |> List.groupBy id
    |> List.map (fun (d, g) -> (d, List.length g))

let popularDigitsMean (list: int list) =
    let freq = digitFrequency list
    let half = float (List.sumBy snd freq) / 2.0
    let popular = freq |> List.filter (fun (_, count) -> float count > half) |> List.map fst
    list |> List.map (fun n ->
        let digits = string (abs n) |> Seq.map (fun c -> int c - int '0') |> List.ofSeq
        let valid = digits |> List.filter (fun d -> List.contains d popular)
        if valid.IsEmpty then 0.0 else float (List.sum valid) / float (List.length valid))

// 9 Элементы с условиями
let isPerfectSquare n list =
    list |> List.exists (fun x -> x * x = n)

let buildSpecialList (list: int list) =
    let rec checkPrev (xs: int list) (sumSoFar: int) (acc: (int * int * int) list) =
        match xs with
        | [] -> List.rev acc
        | x :: tail ->
            let dividesAllPrev = list |> List.take (List.length list - List.length xs) |> List.forall (fun p -> p <> 0 && x % p = 0)
            let greaterThanSum = x > sumSoFar
            let isSquare = isPerfectSquare x list
            let countGreater = list |> List.filter (fun y -> y > x) |> List.length
            let newAcc = if greaterThanSum && isSquare && dividesAllPrev then (x, sumSoFar, countGreater) :: acc else acc
            checkPrev tail (sumSoFar + x) newAcc
    checkPrev list 0 []

// 10 Кортеж списков индексов
let tupleOfIndices (list: int list) =
    let products = 
        list |> List.indexed |> List.collect (fun (i, x) ->
            list |> List.indexed |> List.filter (fun (j, _) -> j > i) |> List.map (fun (j, y) -> (i, j, x * y)))
    let list2 = products |> List.filter (fun (_, _, prod) -> List.contains prod list) |> List.map (fun (_, _, prod) -> list |> List.findIndex (fun x -> x = prod))
    
    let triples = 
        list |> List.indexed |> List.collect (fun (i, x) ->
            list |> List.indexed |> List.filter (fun (j, _) -> j > i) |> List.collect (fun (j, y) ->
                list |> List.indexed |> List.filter (fun (k, _) -> k > j) |> List.map (fun (k, z) -> (i, j, k, x + y + z))))
    let list3 = triples |> List.filter (fun (_, _, _, sum) -> List.contains sum list) |> List.map (fun (_, _, _, sum) -> list |> List.findIndex (fun x -> x = sum))
    
    let divisorsCount = 
        list |> List.indexed |> List.map (fun (i, x) -> (i, list |> List.filter (fun y -> y <> 0 && x % y = 0) |> List.length))
    let list4 = divisorsCount |> List.filter (fun (_, count) -> count = 4) |> List.map fst
    
    (list2 |> List.distinct, list3 |> List.distinct, list4)

let task17 =
    printfn "Выберите задачу (1-10):"
    match Console.ReadLine() |> int with
    | 1 ->
        let seq1 = readIntList ()
        let seq2 = readIntList ()
        let lcs = longestCommonSubsequence seq1 seq2
        printfn "Наибольшая общая подпоследовательность: %A" lcs
    | 2 ->
        let list = readIntList ()
        let result = fiveLists list
        printfn "Кортеж из пяти списков: %A" result
    | 3 ->
        let n = readInt ()
        let pairs = factorPairs n
        printfn "Список кортежей (a, b) для числа N: %A" pairs
    | 4 ->
        let list = readIntList ()
        let triples = pythagoreanTriples list
        printfn "Пифагоровы тройки: %A" triples
    | 5 ->
        let list = readIntList ()
        let result = allPrimeDivisorsPresent list
        printfn "Элементы с полным набором простых делителей: %A" result
    | 6 ->
        let tuples = [(7,3,4,5,6); (2,3,4,6,7); (2,3,4,5,6); (4,3,10,4,5)]
        let result = sortAndConvertTuples tuples
        printfn "Сортировка кортежей и преобразование в числа: %A" result
    | 7 ->
        let list = readIntList ()
        let sorted = sortByDivisorsParam list
        printfn "Упорядочивание по сумме делителей: %A" sorted
    | 8 ->
        let list = readIntList ()
        let means = popularDigitsMean list
        printfn "Среднее арифметическое популярных цифр: %A" means
    | 9 ->
        let list = readIntList ()
        let result = buildSpecialList list
        printfn "Элементы с условиями: %A" result
    | 10 ->
        let list = readIntList ()
        let result = tupleOfIndices list
        printfn "Кортеж списков индексов: %A" result
    | _ -> printfn "Нет такой задачи"