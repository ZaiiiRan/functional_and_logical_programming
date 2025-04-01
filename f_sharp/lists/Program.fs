open System
open BTree

let readList n =
    let rec readListRec n acc =
        match n with
        | 0 -> acc
        | k ->
            let element = Console.ReadLine() |> int
            let newAcc = acc@[element]
            readListRec (k-1) newAcc
    readListRec n []

let rec printList list =
    match list with
    | [] -> Console.WriteLine("\n")
    | head :: tail ->
        Console.WriteLine(head.ToString())
        printList tail

let rec reduceList list (func :int->int->int) (predicate :int->bool) acc =
    match list with
    | [] -> acc
    | head :: tail ->
        match (predicate head) with
        | false -> reduceList tail func predicate acc
        | true -> reduceList tail func predicate (func acc head)

let evenSum list =
    reduceList list (+) (fun x -> (x%2)=0) 0

let oddCount list =
    reduceList list (fun x y -> x + 1) (fun x -> (x%2)>0) 0

let minList list =
    reduceList list (fun x y -> if x < y then x else y) (fun x -> true) System.Int32.MaxValue

let maxList list =
    reduceList list (fun x y -> if x > y then x else y) (fun x -> true) System.Int32.MinValue

let rec freqElement list element count =
    match list with
    | [] -> count
    | head :: tail ->
        match head=element with
        | false -> freqElement tail element count
        | true -> freqElement tail element (count+1)

let rec freqList list mainList currentList =
    match list with
    | [] -> currentList
    | head :: tail -> 
        let freqEl = freqElement mainList head 0
        freqList tail mainList (currentList @ [freqEl])

let pos list el = 
    let rec pos1 list el num = 
        match list with
            |[] -> 0
            |h::t ->    
                if (h = el) then num
                else 
                    let num1 = num + 1
                    pos1 t el num1
    pos1 list el 1

let getIn list pos = 
    let rec getIn1 list num curNum = 
        match list with 
            |[] -> 0
            |h::t -> 
                if num = curNum then h
                else 
                    let newNum = curNum + 1
                    getIn1 t num newNum
    getIn1 list pos 1

let frequencyElement list = 
    let fL = freqList list list []
    let maxFreq = maxList fL
    let index = pos fL maxFreq
    getIn list index

let countSquares list =
    list
    |> List.filter (fun x -> List.exists (fun y -> y * y = x) list)
    |> List.length

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

let sortByLength (strings: string list) =
    strings |> List.sortBy String.length

let readStrings () =
    printfn "Введите строки (пустая строка для завершения):"
    let rec read acc =
        let input = Console.ReadLine()
        if input = "" then List.rev acc
        else read (input :: acc)
    read []


[<EntryPoint>]
let main (argv :string[]) =
    Console.WriteLine("Введите число n:")
    let n = System.Console.ReadLine() |> int

    Console.WriteLine("Ввод элементов:")
    let list = readList n

    Console.WriteLine("Список:")
    printList list

    Console.WriteLine("Количество нечетных элементов списка:")
    Console.WriteLine(oddCount list)

    Console.WriteLine("Сумма четных элементов списка:")
    Console.WriteLine(evenSum list)

    Console.WriteLine("Минимум списка:")
    Console.WriteLine(minList list)

    Console.WriteLine("Самый часто встречающийся элемент:")
    Console.WriteLine(frequencyElement list)

    Console.WriteLine("Сколько элементов могут быть квадратом какого-то из элементов списка:")
    let list2 = [1; 2; 3; 4; 9; 16]
    Console.WriteLine(countSquares list2)

    let listA = [5; 3; 8; 1]
    let listB = [12; 3; 25; 40]
    let listC = [6; 15; 28; 10]

    let result = createTuples listA listB listC

    Console.WriteLine(result)

    let stringList = readStrings()
    let sortedStrings = sortByLength stringList
    Console.WriteLine(sortedStrings)

    let tree = Node("1", Node("2", Nil, Nil), Node("3", Nil, Nil))

    traverse prefix tree

    0