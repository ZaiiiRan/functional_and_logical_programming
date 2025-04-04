module Form

open System
open System.Windows.Forms
open System.Drawing

let form = new Form(Text = "Массивы в F#", Width = 500, Height = 400)

let generateButton = new Button(Text = "Сгенерировать массив", Location = Point(20, 20), Width = 150)
let resultTextBox = new TextBox(Multiline = true, Location = Point(20, 60), 
                    Width = 440, Height = 280, ScrollBars = ScrollBars.Vertical)

let generateNumbersArray() =
    let rec collectNumbers n (acc: ResizeArray<int>) =
        if acc.Count >= 100 then acc
        else
            if n % 13 = 0 || n % 17 = 0 then
                acc.Add(n)
            collectNumbers (n + 1) acc
    
    collectNumbers 1 (ResizeArray<int>()) |> Seq.toArray

let generateHandler _ =
    let numbers = generateNumbersArray()
    
    let formatNumber n = sprintf "%5d" n
    
    let numberStrings = numbers |> Array.map formatNumber
    
    let chunks = 
        numberStrings 
        |> Array.mapi (fun i x -> (i / 10, x))
        |> Array.groupBy fst
        |> Array.map snd
        |> Array.map (Array.map snd)
    
    let formattedLines = 
        chunks 
        |> Array.map (fun chunk -> String.Join(" ", chunk))
    
    let resultText = 
        (String.Join("\n", formattedLines))
    
    resultTextBox.Text <- resultText

form.Controls.Add(generateButton)
form.Controls.Add(resultTextBox)
generateButton.Click.Add(generateHandler)

let startApplication =
    Application.Run(form)
