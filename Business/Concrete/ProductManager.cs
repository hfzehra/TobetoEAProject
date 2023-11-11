using Business.Abstract;
using DataAccess.Abstract;
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
    }
}
