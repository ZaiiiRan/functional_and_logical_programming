module CoprimeTraversal

let rec gcd x y =
    match y with
    | 0 -> x
    | _ -> gcd y (x % y)

let coprimeTraversal number (func :int->int->int) initial =
    let rec traversal number acc candidate =
        match candidate with
        | 0 -> acc
        | _ ->
            let newAcc = if gcd number candidate = 1 then (func acc candidate) else acc
            traversal number newAcc (candidate-1)
    traversal number initial number

let eulerFunction number =
    coprimeTraversal number (fun x y -> x + 1) 0

let coprimeTraversalPredicate number (func :int->int->int) (predicate :int->bool) initial =
    let rec traversal number acc candidate =
        match candidate with
        | 0 -> acc
        | _ ->
            let nextCandidate = candidate-1
            let isCoprime = if gcd number candidate = 1 then true else false
            let flag = predicate candidate
            match flag, isCoprime with
            | true, true -> traversal number (func acc candidate) nextCandidate
            | _, _ -> traversal number acc nextCandidate
    traversal number initial number