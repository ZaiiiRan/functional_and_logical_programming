module Square
open GeometricFigure
open IPrint
open Rectangle


type Square(side: float) =
    inherit Rectangle(side, side)
    override this.ToString() = sprintf "Квадрат: сторона = %f, площадь = %f" side this.Area
    interface IPrint with
        member this.Print() = printfn "%s" (this.ToString())
