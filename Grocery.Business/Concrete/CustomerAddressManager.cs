using Grocery.Business.Abstract;
using Grocery.DataAccess.Abstract;
using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Concrete
{
    public class CustomerAddressManager : ICustomerAddressService
    {
        private ICustomerAddressRepository _addressRepository;
        public CustomerAddressManager(ICustomerAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public void Create(CustomerAdress entity)
        {
            _addressRepository.Create(entity);
        }

        public void Delete(CustomerAdress entity)
        {
            _addressRepository.Delete(entity);
        }

        public List<CustomerAdress> GetAll()
        {
            return _addressRepository.GetAll();
        }

        public CustomerAdress GetById(int id)
        {
            return _addressRepository.GetById(id);
        }

        public void Update(CustomerAdress entity)
        {
            _addressRepository.Update(entity);
        }
    }
}
