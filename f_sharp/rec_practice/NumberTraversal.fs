module NumberTraversal

let rec numberTraversal num (func :int->int->int) acc = 
    match num with
    | 0 -> acc
    | n -> numberTraversal (n/10) func (func acc (n%10))