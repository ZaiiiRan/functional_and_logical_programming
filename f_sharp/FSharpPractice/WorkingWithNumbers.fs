module WorkingWithNumbers
open CoprimeTraversal

let isPrime number =
    let rec check divisor =
        match divisor*divisor > number with
        | true -> true
        | false ->
            match number%divisor with
            | 0 -> false
            | _ -> check (divisor+1)
    if number < 2 then false else check 2

let maxPrimeDivisor number =
    let rec find num divisor max =
        match divisor > (num/2) with
        | true -> max
        | false ->
            let nextDivisor = (divisor+1)
            match num%divisor with
            | 0 when isPrime divisor -> find num nextDivisor divisor
            | _ -> find num nextDivisor max
    find number 2 1

let rec numberTraversalPredicate num (func :int->int->int) acc (predicate :int->bool) =
    match num with
    | 0 -> acc
    | n -> 
        let digit = n%10
        let next = n/10
        let flag = predicate digit
        match flag with
        | false -> numberTraversalPredicate next func acc predicate
        | true -> numberTraversalPredicate next func (func acc digit) predicate

let productOfDigitsNotDivisibleBy5 number =
    numberTraversalPredicate number (*) 1 (fun x -> x%5 > 0)