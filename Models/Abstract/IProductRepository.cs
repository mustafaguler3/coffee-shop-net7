using System.Collections;

namespace CoffeShop.Models.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetTrendingProducts();
        Product? GetProductDetail(int id);
    }
}
