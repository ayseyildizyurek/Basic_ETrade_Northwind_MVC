 using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
	public class CartController : Controller
	{
		private ICartService _cartService;
		private ICartSessionHelper _cartSessionHelper;
		private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
			_cartSessionHelper = cartSessionHelper;
			_productService = productService;
        }

		public IActionResult AddToCart(int productId)
		{
			//Sepetten ürünü çek idye göre
			Product product = _productService.GetById(productId);

			var cart = _cartSessionHelper.GetCart("cart");
			_cartService.AddToCart(cart, product);
			_cartSessionHelper.SetCart("cart",cart);

			TempData.Add("message", product.ProductName + " Sepete Eklendi");

			return RedirectToAction("Index","Product");
		}

		public IActionResult Index()
		{
			var model = new CartListViewModel
			{
				Cart = _cartSessionHelper.GetCart("cart")
			};
			return View(model);
		}
		public IActionResult RemoveFromCart(int productId)
		{
			Product product = _productService.GetById(productId);
			var cart = _cartSessionHelper.GetCart("cart");
			_cartService.RemoveFromCart(cart, productId);
			_cartSessionHelper.SetCart("cart",cart);

            TempData.Add("message", product.ProductName + " Sepetten Çıkarıldı");

            return RedirectToAction("Index", "Cart");
		}

		//Siparişi tamamlama işlemi

		public IActionResult Complete()
		{
			var model = new ShippingDetailsViewModel
			{
				ShippingDetail=new ShippingDetail()

            };
			return View(model);
		}

		[HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid) //modelin durumuı gerçeli değilse
            {
				return View();
            }
            TempData.Add("message", "Siparişiniz başarıyla tamamlandı");
			_cartSessionHelper.Clear();
			return RedirectToAction("Index", "Cart");
        }
    }
}
