module Task18
open System

let readIntArray () =
    printfn "Введите элементы массива через пробел:"
    let input = Console.ReadLine()
    try
        if String.IsNullOrWhiteSpace input then
            [||]
        else
            input.Split(' ')
            |> Array.filter (fun s -> not (String.IsNullOrWhiteSpace s))
            |> Array.map int
    with
    | :? FormatException ->
        [||]
    | ex ->
        [||]

// 1 Обратный порядок массива
let reverseArray (arr: 'a[]) =
    Array.rev arr

// 2 Копирование последнего элемента из B в A
let appendLastElement (a: 'a[]) (b: 'a[]) =
    if b.Length = 0 then a
    else Array.append a [|b.[b.Length - 1]|]

// 3 Объединение двух массивов
let concatenateArrays (a: 'a[]) (b: 'a[]) =
    Array.append a b

// 4 Фильтр элементов, делящихся на 3
let filterDivisibleBy3 (arr: int[]) =
    arr |> Array.filter (fun x -> x % 3 = 0)

// 5 Разность чисел, представленных массивами
let subtractNumbersFromArrays (arr1: int[]) (arr2: int[]) =
    let toNumber arr =
        arr |> Array.map string |> String.concat "" |> int
    let num1 = toNumber arr1
    let num2 = toNumber arr2
    num1 - num2

// 6 Объединение множеств (хотя бы в одном массиве)
let unionArrays (arr1: int[]) (arr2: int[]) =
    Array.append arr1 arr2 |> Array.distinct

// 7 Пересечение множеств (в обоих массивах)
let intersectArrays (arr1: int[]) (arr2: int[]) =
    arr1 |> Array.filter (fun x -> Array.contains x arr2) |> Array.distinct

// 8 Симметрическая разность множеств (только в одном массиве)
let symmetricDifferenceArrays (arr1: int[]) (arr2: int[]) =
    let union = Array.append arr1 arr2 |> Array.distinct
    let intersect = arr1 |> Array.filter (fun x -> Array.contains x arr2)
    union |> Array.filter (fun x -> not (Array.contains x intersect))

// 9 Первые 100 чисел, делящихся на 13 или 17
let first100DivisibleBy13or17 () =
    Seq.initInfinite id
    |> Seq.filter (fun x -> x % 13 = 0 || x % 17 = 0)
    |> Seq.take 100
    |> Array.ofSeq

// 10 Рациональные корни многочлена
let rationalRoots (coeffs: int[]) =
    let degree = coeffs.Length - 1
    let p0 = coeffs.[degree]
    let pn = coeffs.[0]
    let divisors n = 
        [1..abs n] |> List.filter (fun d -> n % d = 0) |> List.collect (fun d -> [d; -d])
    let p = divisors p0
    let q = divisors pn
    let possibleRoots = 
        p |> List.collect (fun num -> q |> List.map (fun den -> float num / float den))
        |> List.distinct
    possibleRoots |> List.filter (fun r ->
        let x = r
        let result = coeffs |> Array.rev |> Array.mapi (fun i c -> float c * (pown x i)) |> Array.sum
        abs result < 1e-10)

let task18 =
    printfn "Выберите задачу (1-10):"
    match Console.ReadLine() |> int with
    | 1 ->
        let arr = readIntArray ()
        let reversed = reverseArray arr
        printfn "Обратный массив: %A" reversed
    | 2 ->
        let a = [|1; 2; 3|]
        let b = [|4; 5; 7|]
        let result = appendLastElement a b
        printfn "Массив A: %A" a
        printfn "Массив B: %A" b
        printfn "Результат: %A" result
    | 3 ->
        let a = readIntArray ()
        let b = readIntArray ()
        let combined = concatenateArrays a b
        printfn "Объединённый массив: %A" combined
    | 4 ->
        let arr = [|1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12|]
        let filtered = filterDivisibleBy3 arr
        printfn "Исходный массив: %A" arr
        printfn "Отфильтрованный (делятся на 3): %A" filtered
    | 5 ->
        let arr1 = readIntArray ()
        let arr2 = readIntArray ()
        let diff = subtractNumbersFromArrays arr1 arr2
        printfn "Разность: %d" diff
    | 6 ->
        let arr1 = readIntArray ()
        let arr2 = readIntArray ()
        let union = unionArrays arr1 arr2
        printfn "Объединение: %A" union
    | 7 ->
        let arr1 = readIntArray ()
        let arr2 = readIntArray ()
        let intersect = intersectArrays arr1 arr2
        printfn "Пересечение: %A" intersect
    | 8 ->
        let arr1 = readIntArray ()
        let arr2 = readIntArray ()
        let symDiff = symmetricDifferenceArrays arr1 arr2
        printfn "Симметрическая разность: %A" symDiff
    | 9 ->
        let result = first100DivisibleBy13or17 ()
        printfn "Первые 100 чисел, делящихся на 13 или 17: %A" result
    | 10 ->
        let coeffs = readIntArray ()
        let roots = rationalRoots coeffs
        printfn "Коэффициенты: %A" coeffs
        printfn "Рациональные корни: %A" roots
    | _ -> printfn "Нет такой задачи"