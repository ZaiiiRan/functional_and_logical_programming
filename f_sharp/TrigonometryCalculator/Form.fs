module Form

open System
open System.Windows.Forms
open System.Drawing

let form = new Form(Text = "Тригонометрические функции", Width = 400, Height = 300)

let inputLabel = new Label(Text = "Введите угол в градусах:", Location = Point(20, 20), Width = 150)
let inputBox = new TextBox(Location = Point(180, 20), Width = 100)
let resultLabel = new Label(Text = "Результаты:", Location = Point(20, 60), Width = 150)
let cosResult = new Label(Location = Point(180, 60), Width = 200)
let sinResult = new Label(Location = Point(180, 90), Width = 200)
let tanResult = new Label(Location = Point(180, 120), Width = 200)
let calcButton = new Button(Text = "Вычислить", Location = Point(150, 160), Width = 100)

let calculateTrigonometry (degrees: float) =
    let radians = degrees * Math.PI / 180.0
    let cosValue = Math.Cos(radians)
    let sinValue = Math.Sin(radians)
    let tanValue = Math.Tan(radians)
    (cosValue, sinValue, tanValue)

let calculateHandler _ =
    try
        let degrees = float inputBox.Text
        let (cosVal, sinVal, tanVal) = calculateTrigonometry degrees
        
        cosResult.Text <- sprintf "Косинус: %.4f" cosVal
        sinResult.Text <- sprintf "Синус: %.4f" sinVal
        tanResult.Text <- sprintf "Тангенс: %.4f" tanVal
    with
    | _ -> MessageBox.Show("Введите корректное число!", "Ошибка") |> ignore

form.Controls.AddRange([| inputLabel; inputBox; resultLabel; cosResult; sinResult; tanResult; calcButton |])
calcButton.Click.Add(calculateHandler)

let startForm =
    Application.Run(form)