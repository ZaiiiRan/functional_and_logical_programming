open System

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

    0