using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.DataAccess.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetByIdWithProducts(int id);
    }
}
