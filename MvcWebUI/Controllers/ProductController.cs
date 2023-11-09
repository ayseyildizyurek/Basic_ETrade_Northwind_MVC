using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService= productService;
        }
        public IActionResult Index(int categoryId)
        {
            var model = new ProductListViewModel
            {
                Products = categoryId > 0 ?_productService.GetByCategory(categoryId) : _productService.GetAll(),
               
            };
            return View(model);
        }
    }
}
