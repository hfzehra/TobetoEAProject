using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _inProductDal;

        public ProductManager(IProductDal inProductDal)
        {
            _inProductDal = inProductDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //Yetkisi var mı ? kontrolü
            return _inProductDal.GetAll();
            
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _inProductDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _inProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _inProductDal.GetProductDetails();
        }
    }
}
