using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Abstract
{
    public interface ICustomerAddressService
    {
        CustomerAdress GetById(int id);
        List<CustomerAdress> GetAll();
        void Create(CustomerAdress entity);
        void Update(CustomerAdress entity);
        void Delete(CustomerAdress entity);
    }
}
