module ChurchList
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

let pos list el = 
    let rec posRec list el num = 
        match list with
            | [] -> 0
            | h::t ->    
                if (h = el) then num
                else 
                    let num1 = num + 1
                    posRec t el num1
    posRec list el 1

let getIn list pos = 
    let rec getInRec list num curNum = 
        match list with 
            | [] -> 0
            | h::t -> 
                if num = curNum then h
                else 
                    let newNum = curNum + 1
                    getInRec t num newNum
    getInRec list pos 1

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

let frequencyElement list = 
    let fL = freqList list list []
    let maxFreq = maxList fL
    let index = pos fL maxFreq
    getIn list index