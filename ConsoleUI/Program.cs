using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager _productManager = new ProductManager(new EfProductDal());
            //foreach (var product in _productManager.GetByUnitPrice(40,100))
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            //_productManager.Add(new Product(){UnitPrice = 1500, CategoryId = 1,
            //    ProductName = "deneme",UnitsInStock = 1});
            var result = _productManager.GetByUnitPrice(1500, 1500);
            foreach (var product in result)
            {
                Console.WriteLine("{0}--{1}--{2}",product.ProductName,product.UnitPrice,
                    product.UnitsInStock);
            }
        }
    }
}