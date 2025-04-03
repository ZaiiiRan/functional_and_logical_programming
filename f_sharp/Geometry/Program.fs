open Rectangle
open Square
open Circle
open IPrint
open GeometricFigureDU

[<EntryPoint>]
let main (argv :string[]) =
    let rect = Rectangle.Rectangle(3.0, 4.0) :> IPrint
    let square = Square.Square(5.0) :> IPrint
    let circle = Circle.Circle(2.5) :> IPrint

    rect.Print()
    square.Print()
    circle.Print()

    let figures = [
        GeometricFigureDU.Rectangle(3.0, 4.0)
        GeometricFigureDU.Square(5.0)
        GeometricFigureDU.Circle(2.5)
    ]

    figures |> List.iter (fun figure ->
        match figure with
        | GeometricFigureDU.Rectangle(width, height) -> 
            printfn "Прямоугольник: площадь = %f" (calculateArea figure)
        | GeometricFigureDU.Square(side) -> 
            printfn "Квадрат: площадь = %f" (calculateArea figure)
        | GeometricFigureDU.Circle(radius) -> 
            printfn "Круг: площадь = %f" (calculateArea figure)
    )
    
    0