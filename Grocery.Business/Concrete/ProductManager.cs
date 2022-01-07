using Grocery.Business.Abstract;
using Grocery.DataAccess.Abstract;
using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Concrete
{
    public class ProductManager : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public string ErorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Create(Product entity)
        {
            if (Validate(entity))
            {
                _productRepository.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetProductsByCategory(category);
        }

        public Product GetProductDetails(int id)
        {
            return _productRepository.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(category, page, pageSize);
        }

        public void Update(Product entity)
        {
             _productRepository.Update(entity);
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _productRepository.Update(entity, categoryIds);
        }

        public bool Validate(Product entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErorMessage += "The product name cannot be blank.";
                isValid = false;
            }
            return isValid;
        }
    }
}
