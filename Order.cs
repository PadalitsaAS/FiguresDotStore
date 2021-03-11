namespace FiguresDotStore.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="positions">Список позиций.</param>
        public Order(IEnumerable<Position> positions)
        {
            if (positions == null)
            {
                throw new System.ArgumentNullException(nameof(positions));
            }

            this.Figures = positions.Select(p => p.CreateFigure());
        }

        /// <summary>
        /// Gets фигуры заказа.
        /// Переименовал Positions -> Figures.
        /// </summary>
        public IEnumerable<Figure> Figures { get; }

        /// <summary>
        /// Gets суммарная площадь треугольников и кругов.
        /// </summary>
        public decimal GetTotal =>
            this.Figures.OfType<Triangle>().Sum(p => (decimal)p.GetArea() * 1.2m) +
            this.Figures.OfType<Circle>().Sum(p => (decimal)p.GetArea() * 0.9m);
    }
}