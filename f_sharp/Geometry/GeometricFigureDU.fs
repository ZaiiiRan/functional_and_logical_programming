module GeometricFigureDU
open System

type GeometricFigureDU =
    | Rectangle of width: float * height: float
    | Square of side: float
    | Circle of radius: float

let calculateArea figure =
    match figure with
    | Rectangle(width, height) -> width * height
    | Square(side) -> side * side
    | Circle(radius) -> System.Math.PI * radius * radius