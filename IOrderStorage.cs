namespace FiguresDotStore.Controllers
{
    using System.Threading.Tasks;

    /// <summary>
    /// Интерфейс хранилища заказов.
    /// </summary>
    public interface IOrderStorage
    {
        /// <summary>
        /// сохраняет оформленный заказ и возвращает сумму.
        /// </summary>
        /// <param name="order">Заказ.</param>
        /// <returns>Результат.</returns>
        Task<decimal> Save(Order order);
    }
}
