
using CoffeShop.Data;
using CoffeShop.Models.Abstract;

namespace CoffeShop.Models.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private ShopContext _dbContext;

        public ProductRepository(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public Product? GetProductDetail(int id)
        {
            return _dbContext.Products.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            return _dbContext.Products.Where(p => p.IsTrendingProduct);
        }
    }
}
