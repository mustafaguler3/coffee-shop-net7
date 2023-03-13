using CoffeShop.Data;
using CoffeShop.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Models.Concrete
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private ShopContext dbContext;

        public ShoppingCartRepository(ShopContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ShoppingCart>? ShoppingCartItems { get; set; }
        public string? ShoppingCartId { get; set; }
        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            ShopContext context = services.GetService<ShopContext>() ?? throw new Exception("Error initializing coffeshopdb");
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);

            return new ShoppingCartRepository(context)
            {
                ShoppingCartId= cartId
            };
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = dbContext.ShoppingCart.FirstOrDefault(i => i.Product.Id == product.Id && i.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCart()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Qty = 1
                };
                dbContext.ShoppingCart.Add(shoppingCartItem);
            }else
            {
                shoppingCartItem.Qty++;
            }
            dbContext.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = dbContext.ShoppingCart.Where(i => i.ShoppingCartId == ShoppingCartId);
            dbContext.ShoppingCart.RemoveRange(cartItems);
            dbContext.SaveChanges();
        }

        public List<ShoppingCart> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= dbContext.ShoppingCart.Where(x => x.ShoppingCartId == ShoppingCartId).Include(i => i.Product).ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var totalCost = dbContext.ShoppingCart.Where(i => i.ShoppingCartId == ShoppingCartId).Select(i => i.Product.Price * i.Qty).Sum();
            return (decimal)totalCost;
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = dbContext.ShoppingCart.FirstOrDefault(i => i.Product.Id == product.Id && i.ShoppingCartId == ShoppingCartId);
            var quantity = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Qty > 1)
                {
                    shoppingCartItem.Qty--;
                    quantity = shoppingCartItem.Qty;
                }else
                {
                    dbContext.ShoppingCart.Remove(shoppingCartItem);
                }                
            }
            dbContext.SaveChanges();

            return quantity;
        }
    }
}
