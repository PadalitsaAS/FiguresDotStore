namespace FiguresDotStore.Controllers
{
    using System.Collections.Generic;

    /// <summary>
    /// Фигура.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Gets or sets сторона А.
        /// </summary>
        public float SideA { get; set; }

        /// <summary>
        /// Gets or sets список ошибок.
        /// </summary>
        public IEnumerable<string> ValidationErrors { get; protected set; }

        /// <summary>
        /// Проверка.
        /// </summary>
        public abstract void Validate();

        /// <summary>
        /// Получить площадь.
        /// </summary>
        /// <returns>площадь фигуры.</returns>
        public abstract double GetArea();
    }
}