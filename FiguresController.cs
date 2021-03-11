namespace FiguresDotStore.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер заказа.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FiguresController : ControllerBase
    {
        // удалил логгер, т.к. не используется
        private readonly IOrderStorage orderStorage;

        // убрал статику
        private readonly IFiguresStorage figuresStorage;
        private readonly IOrderValidator orderValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FiguresController"/> class.
        /// </summary>
        /// <param name="orderStorage">Хранилище заказов. реализация IOrderStorage, должна быть зарегистрирована в DI.</param>
        /// <param name="figuresStorage">Хранилище фигур, реализация IFiguresStorage, должна быть зарегистрирована в DI.</param>
        /// <param name="orderValidator">Проверщик заказа. реализация IOrderValidator, должна быть зарегистрирована в DI.</param>
        public FiguresController(
            IOrderStorage orderStorage,
            IFiguresStorage figuresStorage,
            IOrderValidator orderValidator)
        {
            this.orderStorage = orderStorage;
            this.figuresStorage = figuresStorage;
            this.orderValidator = orderValidator;
        }

        /// <summary>
        /// Хотим оформить заказ и получить в ответе его стоимость.
        /// </summary>
        /// <param name="cart">Карточка заказа.</param>
        /// <returns>Результат заказа.</returns>
        [HttpPost]
        public async Task<ActionResult> Order(Cart cart)
        {
            // проверяем, что карточка не null
            if (cart is null)
            {
                throw new System.ArgumentNullException(nameof(cart));
            }

            if (!this.figuresStorage.CheckIfAvailable(cart))
            {
                return new BadRequestResult();
            }

            var order = new Order(cart.Positions);
            this.orderValidator.Validate(order);

            this.figuresStorage.Reserve(cart);

            // добавляем ожидание результата, с помощью оператора await
            var result = await this.orderStorage.Save(order);

            // возвращаем результат
            return new OkObjectResult(result);
        }
    }
}