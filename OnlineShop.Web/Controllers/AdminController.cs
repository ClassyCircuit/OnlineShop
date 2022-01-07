using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Business.Services;
using OnlineShop.Data.Tables;
using OnlineShop.Web.Models;

namespace OnlineShop.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ProductService _productService;
        private readonly ImageService _imageService;

        public AdminController(ILogger<AdminController> logger,
                               ProductService productService,
                               ImageService imageService)
        {
            _logger = logger;
            _productService = productService;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var categories = _productService.GetProductCategories();
            var model = new ProductViewModel();
            model.Categories = categories.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel model)
        {
            string path = await _imageService.SaveImage(model.Image);
            var categories = _productService.GetProductCategories();

            _productService.AddProduct(new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Category = categories.Single(t => t.Id == int.Parse(model.CategoryId)),
                ImagePath = path
            });

            return RedirectToAction(nameof(AddProduct));
        }



    }
}