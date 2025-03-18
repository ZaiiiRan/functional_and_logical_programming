module QuadraticEquation

type SolveEquationResult =
    None
    | Linear of float
    | Quadratic of float*float

let solveEquation a b c =
    let D = b*b - 4.0*a*c
    if a=0. then
        if b=0. then None
        else Linear(-c/b)
    else
        if D<0. then None
        else Quadratic(((-b+sqrt(D))/(2.0*a), (-b-sqrt(D))/(2.0*a)))