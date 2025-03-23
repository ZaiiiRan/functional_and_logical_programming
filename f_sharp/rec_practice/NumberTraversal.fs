module NumberTraversal

let rec numberTraversal num (func :int->int->int) acc = 
    match num with
    | 0 -> acc
    | n -> numberTraversal (n/10) func (func acc (n%10))

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