open FParsec

type Expression =
    | Number of int
    | String of string
    | Boolean of bool
    | Identifier of string
    | List of Expression list
    | Operation of string * Expression * Expression

// Основные парсеры
let pstringLiteral =
    let normalChar = satisfy (fun c -> c <> '\\' && c <> '"')
    let escapedChar = 
        pstring "\\" >>. (anyOf "\\nrt\"" |>> function
                            | 'n' -> '\n'
                            | 'r' -> '\r'
                            | 't' -> '\t'
                            | c -> c)
    between (pstring "\"") (pstring "\"")
            (manyChars (normalChar <|> escapedChar))
    |>> String

let pnumber = pint32 |>> Number

let pboolean = 
    (stringReturn "true" (Boolean true)) <|> 
    (stringReturn "false" (Boolean false))

let pidentifier =
    let isIdentifierFirstChar c = isLetter c || c = '_'
    let isIdentifierChar c = isLetter c || isDigit c || c = '_'
    many1Satisfy2 isIdentifierFirstChar isIdentifierChar
    |>> Identifier

let pwhitespace = spaces

let createParser() =
    let pexpr, pexprRef = createParserForwardedToRef()
    let plist = 
        between (pstring "(") (pstring ")") 
            (sepBy pexpr pwhitespace |>> List)

    pexprRef := choice [
        attempt pstringLiteral
        attempt pnumber
        attempt pboolean
        attempt pidentifier
        attempt plist
    ]

    pexpr

let pexpr = createParser()

let poperation =
    let opp = new OperatorPrecedenceParser<Expression,unit,unit>()
    let expr = opp.ExpressionParser
    
    opp.TermParser <- pexpr .>> pwhitespace
    
    opp.AddOperator(InfixOperator("+", pwhitespace, 1, Associativity.Left, 
                    fun x y -> Operation("+", x, y)))
    opp.AddOperator(InfixOperator("-", pwhitespace, 1, Associativity.Left, 
                    fun x y -> Operation("-", x, y)))
    opp.AddOperator(InfixOperator("*", pwhitespace, 2, Associativity.Left, 
                    fun x y -> Operation("*", x, y)))
    opp.AddOperator(InfixOperator("/", pwhitespace, 2, Associativity.Left, 
                    fun x y -> Operation("/", x, y)))
    
    expr

let pprogram = pwhitespace >>. poperation .>> pwhitespace .>> eof

let parseString str =
    match run pprogram str with
    | Success(result, _, _) -> 
        printfn "Успешный разбор: %A" result
        Some result
    | Failure(errorMsg, _, _) -> 
        printfn "Ошибка разбора: %s" errorMsg
        None

[<EntryPoint>]
let main argv =
    let examples = [
        "(+ 1 (* 2 3))"
        "\"hello world\""
        "(1 2 3 true false abc)"
        "1 + 2 * 3"
    ]

    examples |> List.iter (fun ex ->
        printfn "\nРазбор примера: %s" ex
        parseString ex |> ignore)
    0