namespace FiguresDotStore.Controllers
{
    using System.Linq;

    /// <summary>
    /// Проверяет заказ.
    /// </summary>
    public class OrderValidator : IOrderValidator
    {
        /// <inheritdoc/>
        public void Validate(Order order)
        {
            if (order is null)
            {
                throw new System.ArgumentNullException(nameof(order));
            }

            if (order.Figures is null || !order.Figures.Any())
            {
                throw new System.Exception("Order is empty");
            }

            foreach (var figure in order.Figures)
            {
                if (figure == null)
                {
                    throw new System.Exception("Order figure is empty");
                }

                figure.Validate();

                if (figure.ValidationErrors != null && figure.ValidationErrors.Any())
                {
                    throw new System.Exception("Order figure is invalid");
                }
            }
        }
    }
}
