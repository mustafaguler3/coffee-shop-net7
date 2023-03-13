using CoffeShop.Models.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Shop()
        {
            return View(productRepository.GetAll());
        }

        public IActionResult Detail(int id)
        {
            var product = productRepository.GetProductDetail(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
