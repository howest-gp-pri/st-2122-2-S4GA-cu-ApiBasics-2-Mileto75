using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Repositories;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ItemResultModel<Product>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            ItemResultModel<Product> itemResultModel = new ItemResultModel<Product>();
            if(products != null)
            {
                itemResultModel.Items = products;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }
            itemResultModel.ValidationErrors = new List<ValidationResult> {
                new ValidationResult("No products found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Product>> GetByIdAsync(int id)
        {
            ItemResultModel<Product> itemResultModel = new ItemResultModel<Product>();
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No product found!")
                };
                return itemResultModel;
            }
            itemResultModel.Items = new List<Product> { product};
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }
    }
}
