namespace FiguresDotStore.Controllers
{
    using System.Collections.Generic;

    /// <summary>
    /// Квадрат.
    /// </summary>
    public class Square : Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="sideA">сторона А.</param>
        /// <param name="sideB">сторона B.</param>
        public Square(float sideA, float sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        /// <summary>
        /// Gets or sets сторона B.
        /// </summary>
        public float SideB { get; set; }

        /// <inheritdoc/>
        public override void Validate()
        {
            var errorList = new List<string>();

            if (this.SideA < 0)
            {
                errorList.Add("Negative side length");
            }

            if (this.SideA != this.SideB)
            {
                errorList.Add("Square restrictions not met");
            }

            if (errorList.Count > 0)
            {
                this.ValidationErrors = errorList;
            }
        }

        /// <inheritdoc/>
        public override double GetArea() => this.SideA * this.SideA;
    }
}