open System
open HelloWorld
open QuadraticEquation
open Cylinder
open SumDigits

[<EntryPoint>]
let main (argv :string[]) =
    printHelloWorld

    Console.WriteLine("---------------------")
    Console.WriteLine("Решение квадратного уравнения")

    let eqRes = solveEquation 1.0 2.0 -3.0
    match eqRes with
        None -> Console.WriteLine("Нет решений")
        | Linear(x) -> printfn "Линейное уравнение: x=%f" x
        | Quadratic(x1, x2) -> printfn "Квадратное уравнение: x1=%f x2=%f" x1 x2

    Console.WriteLine("---------------------")
    Console.WriteLine("Объем цилиндра (каррирование)")

    Console.WriteLine("Введите радиус:")
    let r = System.Console.ReadLine() |> float
    Console.WriteLine("Введите высоту:")
    let h = System.Console.ReadLine() |> float

    let volume1 = cylinderVolume r h
    printfn "Объем цилиндра: %f" volume1

    Console.WriteLine("---------------------")
    Console.WriteLine("Объем цилиндра (суперпозиция)")

    let volume2 = cylinderVolumeSuperPosition r h
    printfn "Объем цилиндра: %f" volume2

    Console.WriteLine("---------------------")
    Console.WriteLine("Сумма цифр числа (рекурсия вверх)")

    Console.Write("Введите число: ")
    let number = Console.ReadLine() |> int

    let sum1 = sumDigitsUp number
    printfn "Сумма цифр числа равна %d" sum1

    Console.WriteLine("---------------------")
    Console.WriteLine("Сумма цифр числа (рекурсия вниз)")

    let sum2 = sumDigitsDown number
    printfn "Сумма цифр числа равна %d" sum2

    0