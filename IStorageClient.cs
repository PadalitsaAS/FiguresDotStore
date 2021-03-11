namespace FiguresDotStore.Controllers
{
    /// <summary>
    /// Интерфейс работы с хранилищем.
    /// Переименовал в IStorageClient, т.к. реализация может быть не на Redis.
    /// </summary>
    internal interface IStorageClient
    {
        /// <summary>
        /// Получить количество типов фигур.
        /// </summary>
        /// <param name="type">Тип фигуры.</param>
        /// <returns>Текущее количество.</returns>
        int Get(string type);

        /// <summary>
        /// Установить нужное количество типов фигур.
        /// </summary>
        /// <param name="type">Тип фигуры.</param>
        /// <param name="current">Текущее количество.</param>
        void Set(string type, int current);
    }
}