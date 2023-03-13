namespace CoffeShop.Models.Abstract
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
    }
}
