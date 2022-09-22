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
            //Data Transformation Object
            ProductManager _productManager = new ProductManager(new EfProductDal());
            //GetByUnitPriceTest(_productManager);
            ProductTest(_productManager);
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in _categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void GetByUnitPriceTest(ProductManager _productManager)
        {
            foreach (var product in _productManager.GetByUnitPrice(40, 100).Data)
            {
                Console.WriteLine(product.ProductName);
            }

            _productManager.Add(new Product()
            {
                UnitPrice = 1500,
                CategoryId = 1,
                ProductName = "deneme",
                UnitsInStock = 1
            });
        }

        private static void ProductTest(ProductManager _productManager)
        {
            var result = _productManager.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var product in result.Data )
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}