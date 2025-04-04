module Form
open System
open System.Drawing
open System.Windows.Forms

let form = new Form(Text = "WinForms F#", Size = Size(400, 200))
let textBox = new TextBox(Location = Point(20, 20), Width = 350)
let progressBar = new ProgressBar(Location = Point(20, 60), Width = 350, Minimum = 0, Maximum = 100)

let addTextChangedActionListener (listener: EventHandler) = 
    textBox.TextChanged.AddHandler(listener)

form.Controls.Add(textBox)
form.Controls.Add(progressBar)

let startForm () =
    Application.Run(form)
