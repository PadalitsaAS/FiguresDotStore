namespace FiguresDotStore.Controllers
{
    using System;

    /// <summary>
    /// Треугольник.
    /// </summary>
    public class Triangle : Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="sideA">сторона А.</param>
        /// <param name="sideB">сторона B.</param>
        /// <param name="sideC">сторона C.</param>
        public Triangle(float sideA, float sideB, float sideC)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        /// <summary>
        /// Gets or sets сторона B.
        /// </summary>
        public float SideB { get; set; }

        /// <summary>
        /// Gets or sets сторона C.
        /// </summary>
        public float SideC { get; set; }

        /// <inheritdoc/>
        public override void Validate()
        {
            static bool CheckTriangleInequality(float a, float b, float c) => a < b + c;

            if (CheckTriangleInequality(this.SideA, this.SideB, this.SideC)
                && CheckTriangleInequality(this.SideB, this.SideA, this.SideC)
                && CheckTriangleInequality(this.SideC, this.SideB, this.SideA))
            {
                return;
            }

            this.ValidationErrors = new[] { "Triangle restrictions not met" };
        }

        /// <inheritdoc/>
        public override double GetArea()
        {
            var p = (this.SideA + this.SideB + this.SideC) / 2;

            return Math.Sqrt(p * (p - this.SideA) * (p - this.SideB) * (p - this.SideC));
        }
    }
}