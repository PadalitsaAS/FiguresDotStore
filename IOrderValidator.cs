namespace FiguresDotStore.Controllers
{
    /// <summary>
    /// Интерфейс проверки заказа.
    /// </summary>
    public interface IOrderValidator
    {
        /// <summary>
        /// Выполнить проверку.
        /// </summary>
        /// <param name="order">Заказ.</param>
        void Validate(Order order);
    }
}
