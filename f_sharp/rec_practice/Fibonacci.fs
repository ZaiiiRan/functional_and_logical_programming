module Fibonacci

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