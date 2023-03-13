namespace CoffeShop.Models.Abstract
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Product product);
        int RemoveFromCart(Product product);
        List<ShoppingCart> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        public List<ShoppingCart>? ShoppingCartItems { get; set; }
    }
}
