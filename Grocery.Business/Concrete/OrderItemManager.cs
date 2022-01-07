using Grocery.Business.Abstract;
using Grocery.DataAccess.Abstract;
using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemManager(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;

        }
        public List<OrderItem> GetAll()
        {

            return _orderItemRepository.GetAll();
            
        }
    }
}
