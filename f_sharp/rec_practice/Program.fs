open System
open NumberTraversal

let testNumberTraversal () = 
    Console.WriteLine("Сумма цифр числа 912:")
    let digitSum = numberTraversal 912 (fun x y -> (x+y)) 0
    Console.WriteLine(digitSum)

    Console.WriteLine("Произведение цифр числа 912:")
    let digitMult = numberTraversal 912 (fun x y -> (x*y)) 1
    Console.WriteLine(digitMult)

    Console.WriteLine("Максимум цифр числа 912:")
    let digitMax = numberTraversal 912 (fun x y -> if x > y then x else y) -1
    Console.WriteLine(digitMax)

    Console.WriteLine("Минимум цифр числа 912:")
    let digitMin = numberTraversal 912 (fun x y -> if x < y then x else y) 10
    Console.WriteLine(digitMin)

    Console.WriteLine("Количество цифр числа 912:")
    let digitCount = numberTraversal 912 (fun x y -> (x+1)) 0
    Console.WriteLine(digitCount)

[<EntryPoint>]
let main (argv :string[]) = 
    let evenSum =  numberTraversalPredicate 8123 (fun x y -> (x+y)) 0 (fun x -> (x%2)=0)
    Console.WriteLine(evenSum)
    0