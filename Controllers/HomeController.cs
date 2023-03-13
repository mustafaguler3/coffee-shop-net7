using CoffeShop.Models;
using CoffeShop.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {            
            return View(productRepository.GetTrendingProducts());
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Send()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}