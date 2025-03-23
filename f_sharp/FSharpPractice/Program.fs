open System
open FavouriteProgrammingLanguage

let askAboutFavouriteLang () = 
    Console.WriteLine("Какой у вас любимый язык программирования?")
    let answer = Console.ReadLine()
    Console.WriteLine(favouriteProgrammingLanguage answer)

[<EntryPoint>]
let main argv =
    askAboutFavouriteLang ()
    0