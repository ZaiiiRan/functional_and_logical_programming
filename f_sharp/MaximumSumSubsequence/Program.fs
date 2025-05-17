open System

let size = 2000
let last = size - 1

// Перевод табличных координат x и y в координату x одномерного массива
let index x y = y * size + x

// Генерация последовательности (таблицы) по условию
let generateSequence () =
    let rec generator (acc: Map<int, int>) k =
        seq {
            match k >= size * size with
            | true -> ()
            | false ->
                let next =
                    match k < 55 with
                    | true ->
                        let kL = int64 (k + 1)
                        int ((100003L - 200003L * kL + 300007L * kL * kL * kL) % 1000000L - 500000L)
                    | _ ->
                        let a = acc.[k - 24]
                        let b = acc.[k - 55]
                        (a + b + 1000000) % 1000000 - 500000
                yield next
                let newAcc = acc.Add(k, next)
                yield! generator newAcc (k + 1)
        }

    generator Map.empty 0
    |> Seq.take (size * size)
    |> Seq.toArray

// Алгоритм Каданы для поиска максимальной суммы элементов в подмассивах в массиве
let maxSum (data: int[]) first last increment =
    let rec loop i currentSum maxSum =
        match i > last with
        | true -> maxSum
        | _ ->
            let newSum = currentSum + data[i]
            let newCurrentSum = if newSum < 0 then 0 else newSum
            let newMaxSum = max maxSum newCurrentSum
            loop (i + increment) newCurrentSum newMaxSum
    
    let initialMax = data.[first]
    loop first 0 initialMax

let findMaximumSum () =
    let data = generateSequence ()
    let initialMax = data[0]

    // Функция обхода
    let lineMax (firstIdxFunc :int->int) (lastIdxFunc :int->int) (increment :int) (startLeadingCooridnate :int) (currentMaximum :int) =
        let rec loop leadingCoordinate acc =
            match (leadingCoordinate > last) with
            | true -> acc
            | _ ->
                let firstIdx = firstIdxFunc leadingCoordinate
                let lastIdx = lastIdxFunc leadingCoordinate
                let sum = maxSum data firstIdx lastIdx increment
                loop (leadingCoordinate + 1) (max acc sum)
        loop startLeadingCooridnate currentMaximum
    
    // Горизонтальные линии
    let horizontalMax =
        let firstIdxFunc = fun y -> (index 0 y)
        let lastIdxFunc = fun y -> (index last y)
        let increment = 1
        let startLeadingCooridnate = 0
        let currentMaximum = initialMax
        lineMax firstIdxFunc lastIdxFunc increment startLeadingCooridnate currentMaximum
    
    // Вертикальные линии
    let verticalMax =
        let firstIdxFunc = fun x -> (index x 0)
        let lastIdxFunc = fun x -> (index x last)
        let increment = size
        let startLeadingCooridnate = 0
        let currentMaximum = horizontalMax
        lineMax firstIdxFunc lastIdxFunc increment startLeadingCooridnate currentMaximum
    
    // Верхние диагонали слева направо (включая центральную)
    let upperLeftToRightDiagonalMax =
        let firstIdxFunc = fun x -> (index x 0)
        let lastIdxFunc = fun x -> (index last (last - x))
        let increment = size + 1
        let startLeadingCooridnate = 0
        let currentMaximum = verticalMax
        lineMax firstIdxFunc lastIdxFunc increment startLeadingCooridnate currentMaximum
    
    // Нижние диагонали слева направо (не включая центральную)
    let lowerLeftToRightDiagonalMax =
        let firstIdxFunc = fun y -> (index 0 y)
        let lastIdxFunc = fun y -> (index (last - y) last)
        let increment = size + 1
        let startLeadingCooridnate = 1
        let currentMaximum = upperLeftToRightDiagonalMax
        lineMax firstIdxFunc lastIdxFunc increment startLeadingCooridnate currentMaximum
    
    // Верхние диагонали справа налево (включая центральную)
    let upperRightToLeftDiagonalMax =
        let firstIdxFunc = fun x -> (index x 0)
        let lastIdxFunc = fun x -> (index 0 x)
        let increment = size - 1
        let startLeadingCooridnate = 0
        let currentMaximum = lowerLeftToRightDiagonalMax
        lineMax firstIdxFunc lastIdxFunc increment startLeadingCooridnate currentMaximum
    
    // Нижние диагонали справа налево (не включая центральную)
    let lowerRightToLeftDiagonalMax =
        let firstIdxFunc = fun y -> (index last y)
        let lastIdxFunc = fun y -> (index (last - y) last)
        let increment = size - 1
        let startLeadingCooridnate = 1
        let currentMaximum = upperRightToLeftDiagonalMax
        lineMax firstIdxFunc lastIdxFunc increment startLeadingCooridnate currentMaximum
    
    lowerRightToLeftDiagonalMax

[<EntryPoint>]
let main argv =
    let result = findMaximumSum ()    
    Console.WriteLine(result)

    0