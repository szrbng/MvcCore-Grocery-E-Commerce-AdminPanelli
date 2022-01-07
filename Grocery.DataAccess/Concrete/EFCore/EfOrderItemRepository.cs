using Grocery.DataAccess.Abstract;
using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.DataAccess.Concrete.EFCore
{
    public class EfOrderItemRepository : EfGenericRepository<OrderItem, GroceryContext>, IOrderItemRepository
    {
    }
}
