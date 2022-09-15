using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager _productManager = new ProductManager(new EfProductDal());
            foreach (var product in _productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}