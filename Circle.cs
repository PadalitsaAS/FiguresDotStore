namespace FiguresDotStore.Controllers
{
    using System;

    /// <summary>
    /// Круг.
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">радиус.</param>
        public Circle(float radius)
        {
            this.SideA = radius;
        }

        /// <inheritdoc/>
        public override void Validate()
        {
            if (this.SideA < 0)
            {
                this.ValidationErrors = new[] { "Circle restrictions not met" };
            }
        }

        /// <inheritdoc/>
        public override double GetArea() => Math.PI * this.SideA * this.SideA;
    }
}