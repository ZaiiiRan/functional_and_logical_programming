open System

type Maybe<'a> = 
    | Some of 'a
    | None

module Maybe =
    let ret x = Some x

    let map f = function
        | Some x -> Some (f x)
        | None -> None

    let apply fMaybe xMaybe =
        match fMaybe, xMaybe with
        | Some f, Some x -> Some (f x)
        | _ -> None

    let bind f = function
        | Some x -> f x
        | None -> None

// Законы функтора
let functorIdentityLaw x =
    Maybe.map id x = x

let functorCompositionLaw f g x =
    Maybe.map (f >> g) x = (Maybe.map f >> Maybe.map g) x

// Законы аппликативного функтора
let applicativeIdentityLaw v =
    Maybe.apply (Maybe.ret id) v = v

let applicativeHomomorphismLaw f x =
    Maybe.apply (Maybe.ret f) (Maybe.ret x) = Maybe.ret (f x)

let applicativeInterchangeLaw u y =
    Maybe.apply u (Maybe.ret y) = Maybe.apply (Maybe.ret (fun f -> f y)) u

// Законы монады
let monadLeftIdentityLaw x f =
    Maybe.bind f (Maybe.ret x) = f x

let monadRightIdentityLaw m =
    Maybe.bind Maybe.ret m = m

let monadAssociativityLaw m f g =
    Maybe.bind g (Maybe.bind f m) = Maybe.bind (fun x -> Maybe.bind g (f x)) m

[<EntryPoint>]
let main argv =
    let testValue = Some 5
    let testFunc x = x + 1
    let testFunc2 x = x * 2

    printfn "Functor Identity Law: %b" (functorIdentityLaw testValue)
    printfn "Functor Composition Law: %b" (functorCompositionLaw testFunc testFunc2 testValue)

    printfn "Applicative Identity Law: %b" (applicativeIdentityLaw testValue)
    printfn "Applicative Homomorphism Law: %b" (applicativeHomomorphismLaw testFunc 5)
    printfn "Applicative Interchange Law: %b" (applicativeInterchangeLaw (Some testFunc) 5)

    printfn "Monad Left Identity Law: %b" (monadLeftIdentityLaw 5 (fun x -> Some(x + 1)))
    printfn "Monad Right Identity Law: %b" (monadRightIdentityLaw testValue)
    printfn "Monad Associativity Law: %b" (monadAssociativityLaw testValue (fun x -> Some(x + 1)) (fun y -> Some(y * 2)))

    0