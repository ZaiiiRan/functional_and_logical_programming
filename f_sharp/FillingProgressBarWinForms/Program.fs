open System
open Form

[<EntryPoint>]
let main (argv: string[]) =
    let listener = EventHandler(fun _ _ ->
        let maxLength = 50
        if textBox.Text.Length > maxLength then
            textBox.Text <- textBox.Text.Substring(0, maxLength)
            textBox.SelectionStart <- maxLength
        let progress = min (textBox.Text.Length * 100 / maxLength) 100
        progressBar.Value <- progress
    )
    
    addTextChangedActionListener listener
    startForm()
    0
