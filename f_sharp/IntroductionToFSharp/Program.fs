open System

type SolveResult =
    None
    | Linear of float
    | Quadratic of float*float

let solve a b c =
    let D = b*b - 4.0*a*c
    if a=0. then
        if b=0. then None
        else Linear(-c/b)
    else
        if D<0. then None
        else Quadratic(((-b+sqrt(D))/(2.0*a), (-b-sqrt(D))/(2.0*a)))

let circleArea r = (Math.PI*r*r)
let cylinderVolume r h = (circleArea r) * h

let multiplyAreaH area h = area * h
let cylinderVolumeSuperPosition = (circleArea >> multiplyAreaH)

[<EntryPoint>]
let main (argv :string[]) =
    printfn "Hello World"
    Console.WriteLine("Hello World")

    Console.WriteLine("---------------------")

    let res = solve 1.0 2.0 -3.0
    match res with
        None -> Console.WriteLine("Нет решений")
        | Linear(x) -> printfn "Линейное уравнение: x=%f" x
        | Quadratic(x1, x2) -> printfn "Квадратное уравнение: x1=%f x2=%f" x1 x2

    Console.WriteLine("---------------------")

    Console.WriteLine("Введите радиус:")
    let r = System.Console.ReadLine() |> float
    Console.WriteLine("Введите высоту:")
    let h = System.Console.ReadLine() |> float

    let volume = cylinderVolume r h
    printfn "Объем цилиндра: %f" volume

    Console.WriteLine("---------------------")

    Console.WriteLine("Введите радиус:")
    let r2 = System.Console.ReadLine() |> float
    Console.WriteLine("Введите высоту:")
    let h2 = System.Console.ReadLine() |> float

    let volume2 = cylinderVolumeSuperPosition r h
    printfn "Объем цилиндра: %f" volume2

    Console.WriteLine("---------------------")


    0