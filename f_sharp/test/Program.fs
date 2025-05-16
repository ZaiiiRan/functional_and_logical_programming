open System

let foldD list func initial =
    let rec foldDI list acc =
        match list with
        | [] -> acc
        | h :: t ->
            let newAcc = func acc h
            foldDI t newAcc
    foldDI list initial

let fold list func initial =
    let rec foldI list =
        match list with
        | [] -> 0
        | h :: t ->
            (foldI t) + h
    (foldI list) + initial

let maxList list =
    foldD list (fun x y -> max x y) (List.head list)

let divisorsCount num =
    let absNumber = abs num

    let rec divisorsCountI divisor =
        match divisor < absNumber with
        | false -> 0
        | _ -> 
            let count = if absNumber % divisor = 0 then 1 else 0
            (divisorsCountI (divisor+1)) + count
    
    divisorsCountI 1

let divisorsCountD num =
    let absNumber = abs num

    let rec divisorsCountI divisor acc =
        match divisor < absNumber with
        | false -> acc
        | _ ->
            let newAcc = if absNumber % divisor = 0 then (acc+1) else acc
            divisorsCountI (divisor+1) newAcc
    
    divisorsCountI 1 0

let rec digitCount num =
    match num > 0 with
    | false -> 0
    | _ ->
        (digitCount (num/10)) + 1

let digitCountD num =
    let rec digitCountDI number acc =
        match number > 0 with
        | false -> acc
        | _ ->
            let newAcc = acc + 1
            digitCountDI (number/10) newAcc
    digitCountDI num 0

Console.WriteLine(digitCountD 111)
