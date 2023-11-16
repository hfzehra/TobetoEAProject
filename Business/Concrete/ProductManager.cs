using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        {
            //IResult eklenince return olarak sonuç döndürmeliyiz.
            //Business kodlar buraya eklenir
            if (product.ProductName.Length<2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _inProductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //Yetkisi var mı ? kontrolü
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult();
            }
            return  new SuccessDataResult<List<Product>>(_inProductDal.GetAll(),true,"Ürünler Listelendi");
            
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _inProductDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _inProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public Product GetById(int productId)
        {
            return _inProductDal.Get(p=>p.ProductId == productId);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _inProductDal.GetProductDetails();
        }
    }
}
