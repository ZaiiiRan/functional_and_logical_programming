module TasksWithList

// 1.19 Циклический сдвиг вправо
let shiftRight list =
    match list with
    | [] -> []
    | [x] -> [x]
    | _ -> 
        let rec getLastAndInit lst =
            match lst with
            | [] -> failwith "Пустой список"
            | [x] -> (x, [])
            | h :: t -> 
                let (last, init) = getLastAndInit t
                (last, h :: init)
        let (last, init) = getLastAndInit list
        last :: init

let shiftRightList list =
    match List.rev list with
    | [] -> []
    | last :: rest -> last :: List.rev rest
