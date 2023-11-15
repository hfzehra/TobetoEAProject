using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle, Postgres, MongoDB , SQL Server
            _products = new List<Product> { 
                new Product{ ProductId = 1,CategoryId=1,ProductName = "Bardak", UnitPrice=15,UnitsInStock=10},
                new Product{ ProductId = 2,CategoryId=1,ProductName = "Kamera", UnitPrice=3,UnitsInStock=500},
                new Product{ ProductId = 3,CategoryId=2,ProductName = "Telefon", UnitPrice=2,UnitsInStock=1500},
                new Product{ ProductId = 4,CategoryId=2,ProductName = "Klavye", UnitPrice=150,UnitsInStock=65},
                new Product{ ProductId = 5,CategoryId=2,ProductName = "Fare", UnitPrice=3,UnitsInStock=85},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ olmadan yazım
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.Id == p.Id)
            //    {
            //        productToDelete = p;
            //    }
            //}

            //LINQ - Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //Where koşula göre sıralar.
            return _products.Where(p=> p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün Id'sine sahip olan listedeli ürünü bul 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
