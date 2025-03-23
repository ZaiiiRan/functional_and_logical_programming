module FavouriteProgrammingLanguage
open System

let favouriteProgrammingLanguage lang =
    match lang with
    | "F#" | "Prologue" -> Console.WriteLine("Подлиза")
    | "Go" -> Console.WriteLine("Мое уважение")
    | "Ruby" -> Console.WriteLine("Супер подлиза")
    | "Python" -> Console.WriteLine("Норм")
    | "JavaScript" | "JS" -> Console.WriteLine("JS прикольный. Тоже функциональный))")
    | _ -> Console.WriteLine("Не знаю такого")