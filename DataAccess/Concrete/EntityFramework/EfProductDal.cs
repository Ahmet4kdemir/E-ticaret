﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var result = from p in northwindContext.Products
                             join c in northwindContext.Categories
                                 on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto()
                             {
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 ProductId = p.ProductId,
                                 UnitsInStock = p.UnitsInStock,
                             };
                return result.ToList();
            }
        }
    }
}
