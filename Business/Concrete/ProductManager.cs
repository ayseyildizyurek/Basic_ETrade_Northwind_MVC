using Business.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //EfProductDal kullanacağız ama bağımlılıkları sıfırlamak istiyoruz Dependecy Injection kullanacağız

        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;   
        }
        public List<Product> GetAll()
        {
           return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p=>p.CategoryID == categoryId);
        }

		public Product GetById(int productId)
		{
            return _productDal.Get(p => p.ProductID == productId);
		}
	}
}
