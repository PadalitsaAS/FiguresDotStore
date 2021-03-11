namespace FiguresDotStore.Controllers
{
    using System.Linq;

    /// <summary>
    /// Хранилище фигур.
    /// </summary>
    internal class FiguresStorage : IFiguresStorage
    {
        // корректно сконфигурированный и готовый к использованию клиент Редиса
        private readonly IStorageClient storageClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="FiguresStorage"/> class.
        /// </summary>
        /// <param name="storageClient">Клиент хранилища. реализация IStorageClient, должна быть зарегистрирована в DI.</param>
        public FiguresStorage(IStorageClient storageClient)
        {
            this.storageClient = storageClient;
        }

        /// <inheritdoc/>
        public bool CheckIfAvailable(Cart cart)
        {
            if (cart is null)
            {
                throw new System.ArgumentNullException(nameof(cart));
            }

            if (cart.Positions == null)
            {
                return true;
            }

            return cart.Positions.All(o => this.storageClient.Get(o.Type) >= o.Count);
        }

        /// <inheritdoc/>
        public void Reserve(Cart cart)
        {
            if (cart is null)
            {
                throw new System.ArgumentNullException(nameof(cart));
            }

            if (cart.Positions != null)
            {
                foreach (var position in cart.Positions)
                {
                    var current = this.storageClient.Get(position.Type);

                    this.storageClient.Set(position.Type, current - position.Count);
                }
            }
        }
    }
}
