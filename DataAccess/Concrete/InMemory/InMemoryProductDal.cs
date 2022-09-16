using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;

        public InMemoryProductDal()
        {
            //Oracle,Sql Server, Postgres, MongoDb
            _products = new List<Product>
            {
                new Product(){CategoryId = 1,ProductId = 1,ProductName = "Glass",UnitPrice = 15,UnitsInStock = 15},
                new Product(){CategoryId = 1,ProductId = 2,ProductName = "Spoon",UnitPrice = 500,UnitsInStock = 3},
                new Product(){CategoryId = 2,ProductId = 3,ProductName = "phone",UnitPrice = 1500,UnitsInStock = 2},
                new Product(){CategoryId = 2,ProductId = 4,ProductName = "keyboard",UnitPrice = 150,UnitsInStock = 65},
                new Product(){CategoryId = 2,ProductId = 5,ProductName = "mouse",UnitPrice = 85,UnitsInStock = 1}


            };
        }
        //public List<Product> GetAll()
        //{
        //    return _products;
        //}

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            Product productToUpdate;
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
        }

        public void Delete(Product product)
        {
            // LINQ -- Language Integrated Query
            // Lambda
            Product productToDelete;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}             instead of that long codes we can use easily linq below

            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//******

            _products.Remove(productToDelete);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
