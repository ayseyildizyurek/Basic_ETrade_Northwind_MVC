﻿using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcWebUI.Models;

namespace MvcWebUI.ViewComponents
{
	public class CategoryListViewComponent:ViewComponent
	{
		ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
			_categoryService=categoryService;

		}
        public ViewViewComponentResult Invoke()
		{
			var model = new CategoryListViewModel
			{
				Categories = _categoryService.GetAll(),
				 CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["categoryId"])
			};
			return View(model);
		}
	}
}
