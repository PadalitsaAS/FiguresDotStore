namespace FiguresDotStore.Controllers
{
    /// <summary>
    /// Интерфейс хранилища фигур.
    /// </summary>
    public interface IFiguresStorage
    {
        /// <summary>
        /// Проверка на наличие позиций карточки.
        /// </summary>
        /// <param name="cart">Карточка заказа.</param>
        /// <returns>Результат проверки.</returns>
        bool CheckIfAvailable(Cart cart);

        /// <summary>
        /// Резервируем позиции карточки.
        /// </summary>
        /// <param name="cart">Карточка заказа.</param>
        void Reserve(Cart cart);
    }
}
