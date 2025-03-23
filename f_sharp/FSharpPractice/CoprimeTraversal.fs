module CoprimeTraversal

let rec gcd x y =
    match y with
    | 0 -> x
    | _ -> gcd y (x % y)

let coprimeTraversal number (func :int->int->int) initial =
    let rec traversal number (func :int->int->int) acc candidate =
        if candidate <= 0 then acc
        else
            let newAcc = if gcd number candidate = 1 then (func acc candidate) else acc
            traversal number func newAcc (candidate-1)
    traversal number func initial number

let eulerFunction number =
    coprimeTraversal number (fun x y -> x + 1) 0