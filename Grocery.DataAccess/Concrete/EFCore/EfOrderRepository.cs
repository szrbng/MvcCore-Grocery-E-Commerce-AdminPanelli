using Grocery.DataAccess.Abstract;
using Grocery.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grocery.DataAccess.Concrete.EFCore
{
    public class EfOrderRepository : EfGenericRepository<Order, GroceryContext>, IOrderRepository
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new GroceryContext())
            {
                var orders = context.Orders.Include(i => i.OrderItems).ThenInclude(i => i.Product).AsQueryable();
                if (string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.UserId == userId);
                }
                return orders.ToList();
            }
        }
    }
}
