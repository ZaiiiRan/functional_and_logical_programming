open System
open System.Windows.Controls
open Form

[<STAThread>]
[<EntryPoint>]
let main argv =
    let (window, textBox, progressBar) = createWindow()
    
    let maxLength = 50
    let textChangedHandler = TextChangedEventHandler(fun sender _ ->
        let textBox = sender :?> TextBox
        if textBox.Text.Length > maxLength then
            textBox.Text <- textBox.Text.Substring(0, maxLength)
            textBox.CaretIndex <- maxLength
        
        let progress = min (textBox.Text.Length * 100 / maxLength) 100
        progressBar.Value <- float progress
    )
    
    setupTextChangedHandler textBox textChangedHandler
    startApplication window