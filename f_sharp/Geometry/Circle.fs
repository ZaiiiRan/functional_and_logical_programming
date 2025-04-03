module Circle
open GeometricFigure
open System
open IPrint


type Circle(radius: float) =
    inherit GeometricFigure()
    member val Radius = radius with get, set
    override this.Area = System.Math.PI * this.Radius * this.Radius
    override this.ToString() = sprintf "Круг: радиус = %f, площадь = %f" this.Radius this.Area
    interface IPrint with
        member this.Print() = printfn "%s" (this.ToString())
