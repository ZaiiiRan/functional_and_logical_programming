module Task6

let sumDigits num =
    let rec sumDigitsDownLoop num acc =
        match num with
        | 0 -> acc
        | _ -> sumDigitsDownLoop (num/10) (acc+(num%10))
    sumDigitsDownLoop num 0

let factorial num = 
    let rec factorialDownLoop num acc =
        match num with
        | 0  -> acc
        | _ -> factorialDownLoop (num-1) (acc*num)
    factorialDownLoop num 1

let task6 arg =
    match arg with
    | false -> factorial
    | true -> sumDigits