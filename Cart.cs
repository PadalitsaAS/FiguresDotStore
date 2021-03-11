namespace FiguresDotStore.Controllers
{
    using System.Collections.Generic;

    /// <summary>
    /// Карточка заказа.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Gets or sets позиции заказа.
        /// </summary>
        public IEnumerable<Position> Positions { get; set; }
    }
}