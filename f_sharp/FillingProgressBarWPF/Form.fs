module Form

open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let createWindow() =
    let xaml = """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="WPF Progress" Width="400" Height="200">
    <StackPanel Margin="20">
        <TextBox Name="textBox" Margin="0,0,0,20"/>
        <ProgressBar Name="progressBar" Height="20" Minimum="0" Maximum="100"/>
    </StackPanel>
</Window>
"""
    let window = XamlReader.Parse(xaml) :?> Window
    let textBox = window.FindName("textBox") :?> TextBox
    let progressBar = window.FindName("progressBar") :?> ProgressBar
    (window, textBox, progressBar)

let setupTextChangedHandler (textBox: TextBox) handler =
    textBox.TextChanged.AddHandler(handler)

let startApplication (window: Window) =
    let app = Application()
    app.Run(window)