open System

let rec fibonacciUp num =
    match num with
    | 0 | 1 -> 1
    | num -> (fibonacciUp (num-1)) + (fibonacciUp (num-2))

let fibonacciDown num = 
    let rec fibonacciDownLoop x acc y =
        match y with
        | 0 -> acc
        | _ -> fibonacciDownLoop acc (acc+x) (y-1)
    fibonacciDownLoop 0 1 num

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

let rec numberTraversal num (func :int->int->int) acc = 
    match num with
    | 0 -> acc
    | n -> numberTraversal (n/10) func (func acc (n%10))

[<EntryPoint>]
let main (argv :string[]) = 
    let digitSum = numberTraversal 912 (fun x y -> (x*y)) 1
    Console.WriteLine(digitSum)

    let digitCount = numberTraversal 912 (fun x y -> (x+1)) 0
    Console.WriteLine(digitCount)

    0