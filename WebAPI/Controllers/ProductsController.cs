using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Attribute işlemi
    public class ProductsController : ControllerBase
    {
        //somut sınıf kullanmıyoruz (Dal, Manager gibi)
        //Loosely coupled -> gevşek bağımlılık
        //IoC Container-- Inversion of Control (Değişimin kontrolü)
        //AOF-> Autofac
        //Farklı bir API  tüm konfigürasyon apinin içinde kalır. Bu yüzden bussiness katmanından çekiyoruz.
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Get resquest -> status:200
            //dependecy chain -- Bağımlılık zinciri var
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
