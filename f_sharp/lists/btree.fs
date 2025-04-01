module BTree

type 'string btree = 
    Node of 'string * 'string btree * 'string btree
    | Nil

let prefix root left right = (root(); left(); right())
let infix root left right = (left(); root(); right())
let postfix root left right = (left(); right(); root())

let rec traverse order tree =
    match tree with
    | Node(value, left, right) ->
        order 
            (fun () -> printf "%s " value) 
            (fun () -> traverse order left)
            (fun () -> traverse order right)
    | Nil -> ()