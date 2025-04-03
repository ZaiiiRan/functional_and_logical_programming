module GeometricFigure

[<AbstractClass>]
type GeometricFigure() =
    abstract member Area: float
    override this.ToString() = "Геометрическая фигура"
