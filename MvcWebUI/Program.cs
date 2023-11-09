using Business.Abstract;
using Business.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using FluentValidation.AspNetCore;
using MvcWebUI.Helpers;
using System.Reflection;

namespace MvcWebUI
{
    public class Program
    {
		public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews().AddFluentValidation(option => option.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddSingleton<IProductService,ProductManager>();
            builder.Services.AddSingleton<IProductDal,EfProductDal>();
            builder.Services.AddSingleton<ICategoryService,CategoryManager>();
            builder.Services.AddSingleton<ICategoryDal,EfCategoryDal>();
            builder.Services.AddScoped<ICartService, CartManager>(); //scope yapt�k ��nk� single yaparsak t�m m��terilerin sepeti ayn� olur
            builder.Services.AddScoped<ICartSessionHelper, CartSessionHelper>();
            builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}