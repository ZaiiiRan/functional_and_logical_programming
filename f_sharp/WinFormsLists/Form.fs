module Form

open System
open System.Windows.Forms
open System.Drawing

let form = new Form(Text = "Зеркальный список", Width = 500, Height = 400)

let inputLabel = new Label(Text = "Введите элементы списка:", 
                        Location = Point(20, 20), Width = 200)
let inputTextBox = new TextBox(Location = Point(220, 20), Width = 200)
let processButton = new Button(Text = "Отразить список", 
                        Location = Point(20, 60), Width = 150)
let resultLabel = new Label(Text = "Зеркальный список:", 
                        Location = Point(20, 100), Width = 100)
let resultTextBox = new TextBox(Multiline = true, Location = Point(20, 130), 
                        Width = 440, Height = 200, ScrollBars = ScrollBars.Vertical)

let mirrorList (lst: 'a list) =
    List.rev lst

let processButtonClick _ =
    try
        let input = inputTextBox.Text.Trim()
        let items = 
            if String.IsNullOrEmpty input then []
            else input.Split(';') |> Array.map (fun s -> s.Trim()) |> Array.toList
        
        let mirrored = mirrorList items
        let mirroredText = String.Join("; ", mirrored)
        resultTextBox.Text <- mirroredText
    with
    | ex -> MessageBox.Show(sprintf "Ошибка: %s" ex.Message) |> ignore

form.Controls.AddRange([| inputLabel; inputTextBox; processButton; 
                        resultLabel; resultTextBox |])
processButton.Click.Add(processButtonClick)

let startApplication = 
    Application.Run(form)