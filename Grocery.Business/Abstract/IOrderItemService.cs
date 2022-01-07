using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Abstract
{
    public interface IOrderItemService
    {
        List<OrderItem> GetAll();
    }
}
