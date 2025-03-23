open System
open FavouriteProgrammingLanguage
open CoprimeTraversal
open WorkingWithNumbers

let askAboutFavouriteLangSuperpos () = 
    Console.WriteLine("Какой у вас любимый язык программирования?")
    (Console.ReadLine>>favouriteProgrammingLanguage>>Console.WriteLine)()

let askAboutFavouriteLangCarry () =
    Console.WriteLine("Какой у вас любимый язык программирования?")
    let func read transform write = write (transform (read ())) 
    func Console.ReadLine favouriteProgrammingLanguage Console.WriteLine


let testCoprimeTraversal () =
    let number = 15
    
    Console.WriteLine("Сумма взаимнопростых чисел с числом {0}", number)
    let sum = coprimeTraversal number (+) 0
    Console.WriteLine(sum)

    Console.WriteLine("Произведение взаимнопростых чисел с числом {0}", number)
    let mult = coprimeTraversal number (*) 1
    Console.WriteLine(mult)

    Console.WriteLine("Количество взаимнопростых чисел с числом {0}", number)
    let count = coprimeTraversal number (fun x y -> x + 1) 0
    Console.WriteLine(count)

    Console.WriteLine("Минимум из взаимнопростых чисел с числом {0}", number)
    let min = coprimeTraversal number (fun x y -> if x < y then x else y) number
    Console.WriteLine(min)

    Console.WriteLine("Максимум из взаимнопростых чисел с числом {0}", number)
    let max = coprimeTraversal number (fun x y -> if x > y then x else y) 0
    Console.WriteLine(max)

let testEulerFunction () =
    let number = 15
    Console.WriteLine("Функция Эйлера от {0}", number)
    Console.WriteLine(eulerFunction number)

let testCoprimeTraversalPredicate () =
    let number = 15

    Console.WriteLine("Сумма четных взаимнопростых чисел с числом {0}", number)
    let sum = coprimeTraversalPredicate number (+) (fun x -> (x%2)=0) 0
    Console.WriteLine(sum)


let TaskSelection task number =
    match task with
    | 1 -> maxPrimeDivisor number
    | 2 -> productOfDigitsNotDivisibleBy5 number
    | 3 -> gcdOfMaxOddNonPrimeDivisorAndDigitProduct number
    | _ -> 
        Console.WriteLine("Неверный номер функции")
        0

let workingWithNumbers () = 
    Console.WriteLine("Введите номер функции и аргумент:
    1 - Максимальный простой делитель числа
    2 - Произведение цифр числа, не делящихся на 5
    3 - НОД максимального нечетного непростого делителя числа и произведения цифр данного числа")
    let args = (Console.ReadLine() |> Int32.Parse, Console.ReadLine() |> Int32.Parse)
    let task = fst args
    let number = snd args
    
    let result = TaskSelection task number
    Console.WriteLine(result)

[<EntryPoint>]
let main argv =
    workingWithNumbers ()
    0