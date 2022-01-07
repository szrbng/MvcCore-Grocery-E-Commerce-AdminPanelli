using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.DataAccess.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<Order> GetOrders(string userId);
    }
}
