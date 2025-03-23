open System
open FavouriteProgrammingLanguage
open CoprimeTraversal

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


[<EntryPoint>]
let main argv =
    testEulerFunction ()
    0