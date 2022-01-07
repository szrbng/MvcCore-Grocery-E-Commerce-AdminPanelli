using Grocery.DataAccess.Abstract;
using Grocery.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grocery.DataAccess.Concrete.EFCore
{
    public class EfProductRepository : EfGenericRepository<Product, GroceryContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using (var context = new GroceryContext())
            {
                return context.Products.Where(x => x.ProductId == id).Include(x => x.ProductCategories).ThenInclude(x => x.Category).FirstOrDefault();
            }
        }

        public Product GetProductDetails(int id)
        {
            using (var context = new GroceryContext())
            {
                return context.Products.Where(x => x.ProductId == id).Include(x => x.ProductCategories).ThenInclude(x => x.Category).FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var context = new GroceryContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(x => x.ProductCategories).ThenInclude(x => x.Category).Where(x => x.ProductCategories.Any(z => z.Category.Name.ToLower() == category.ToLower()));
                }
                //paging
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public int GetProductsByCategory(string category)
        {
            using (var context = new GroceryContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(x => x.ProductCategories).ThenInclude(x => x.Category).Where(x => x.ProductCategories.Any(z => z.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Count();
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new GroceryContext())
            {
                var product = context.Products.Include(x => x.ProductCategories).FirstOrDefault(x => x.ProductId == entity.ProductId);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Brand = entity.Brand;
                    product.Description = entity.Description;
                    product.Stock = entity.Stock;
                    product.ImageUrl = entity.ImageUrl;
                    product.Price = entity.Price;
                    product.DiscountedPrice = entity.DiscountedPrice;


                    product.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        CategoryId = catid,
                        ProductId = entity.ProductId
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}
