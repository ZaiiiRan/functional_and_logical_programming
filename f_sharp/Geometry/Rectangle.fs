module Rectangle
open GeometricFigure
open IPrint

type Rectangle(width: float, height: float) =
    inherit GeometricFigure()
    member val Width = width with get, set
    member val Height = height with get, set
    override this.Area = this.Width * this.Height
    override this.ToString() = sprintf "Прямоугольник: ширина = %f, высота = %f, площадь = %f" this.Width this.Height this.Area
    interface IPrint with
        member this.Print() = printfn "%s" (this.ToString())
