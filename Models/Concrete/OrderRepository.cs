using CoffeShop.Data;
using CoffeShop.Models.Abstract;

namespace CoffeShop.Models.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private ShopContext dbContext;
        private IShoppingCartRepository shoppingCartRepository;

        public OrderRepository(ShopContext dbContext, IShoppingCartRepository shoppingCartRepository)
        {
            this.dbContext = dbContext;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public void PlaceOrder(Order order)
        {
            var shoppingCartItems = shoppingCartRepository.GetShoppingCartItems();
            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity =item.Qty,
                    ProductId = item.Product.Id,
                    Price = (decimal)item.Product.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = shoppingCartRepository.GetShoppingCartTotal();
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }
    }
}
