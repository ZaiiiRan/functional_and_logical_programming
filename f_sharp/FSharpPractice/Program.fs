open System
open FavouriteProgrammingLanguage

let askAboutFavouriteLangSuperpos () = 
    Console.WriteLine("Какой у вас любимый язык программирования?")
    (Console.ReadLine>>favouriteProgrammingLanguage>>Console.WriteLine)()

let askAboutFavouriteLangCarry () =
    Console.WriteLine("Какой у вас любимый язык программирования?")
    let func read transform write = write (transform (read ())) 
    func Console.ReadLine favouriteProgrammingLanguage Console.WriteLine

[<EntryPoint>]
let main argv =
    askAboutFavouriteLangSuperpos ()
    askAboutFavouriteLangCarry ()
    0