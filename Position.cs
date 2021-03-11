namespace FiguresDotStore.Controllers
{
    /// <summary>
    /// Позиция заказа.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Gets or sets тип фигуры.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets сторона A.
        /// </summary>
        public float SideA { get; set; }

        /// <summary>
        /// Gets or sets сторона B.
        /// </summary>
        public float SideB { get; set; }

        /// <summary>
        /// Gets or sets сторона C.
        /// </summary>
        public float SideC { get; set; }

        /// <summary>
        /// Gets or sets количество.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Фабричный метод создания фигуры.
        /// </summary>
        /// <returns>Фигура.</returns>
        public Figure CreateFigure()
        {
            Figure figure = null;

            switch (this.Type)
            {
                case "Circle":
                    figure = new Circle(this.SideA);
                    break;
                case "Triangle":
                    figure = new Triangle(this.SideA, this.SideB, this.SideC);
                    break;
                case "Square":
                    figure = new Square(this.SideA, this.SideB);
                    break;
            }

            return figure;
        }
    }
}