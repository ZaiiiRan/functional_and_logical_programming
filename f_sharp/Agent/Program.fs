open System

type AgentMessage =
    | Text of string
    | Number of int
    | Command of string
    | Error of string
    | Quit

let agent = MailboxProcessor<AgentMessage>.Start(fun inbox ->
    let rec loop() = async {
        let! message = inbox.Receive()
        
        match message with
        | Text text ->
            Console.ForegroundColor <- ConsoleColor.Cyan
            printfn "Получен текст: %s" text
            Console.ResetColor()
            
        | Number num ->
            Console.ForegroundColor <- ConsoleColor.Green
            printfn "Получено число: %d" num
            Console.ResetColor()
            
        | Command cmd ->
            Console.ForegroundColor <- ConsoleColor.Yellow
            match cmd.ToLower() with
            | "time" -> printfn "Текущее время: %s" (DateTime.Now.ToString())
            | "date" -> printfn "Сегодня: %s" (DateTime.Today.ToShortDateString())
            | "clear" -> Console.Clear()
            | _ -> printfn "Неизвестная команда: %s" cmd
            Console.ResetColor()
            
        | Error err ->
            Console.ForegroundColor <- ConsoleColor.Red
            printfn "Ошибка: %s" err
            Console.ResetColor()
            
        | Quit ->
            printfn "Завершение работы агента"
            return ()
            
        return! loop()
    }
    loop()
)

let testAgent() =
    printfn "Тестирование агента (введите 'quit' для выхода)"
    
    let rec userInputLoop() =
        printf "Введите текст, число, команду (time/date/clear) или 'quit': "
        let input = Console.ReadLine()
        
        match input with
        | "quit" -> agent.Post Quit
        | "" -> userInputLoop()
        | cmd when cmd.StartsWith("!") -> 
            agent.Post (Command (cmd.Substring(1)))
            userInputLoop()
        | text ->
            match Int32.TryParse(text) with
            | true, num -> agent.Post (Number num)
            | false, _ -> agent.Post (Text text)
            userInputLoop()
    
    userInputLoop()

[<EntryPoint>]
let main argv =
    testAgent()
    0