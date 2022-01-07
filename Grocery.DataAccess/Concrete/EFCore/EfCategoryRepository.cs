using Grocery.DataAccess.Abstract;
using Grocery.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grocery.DataAccess.Concrete.EFCore
{
    public class EfCategoryRepository : EfGenericRepository<Category, GroceryContext>, ICategoryRepository
    {
        public Category GetByIdWithProducts(int id)
        {
            using (var context = new GroceryContext())
            {
                return context.Categories.Where(x => x.Id == id).Include(x => x.ProductCategories).ThenInclude(x => x.Product).FirstOrDefault();
            }
        }
    }
}
