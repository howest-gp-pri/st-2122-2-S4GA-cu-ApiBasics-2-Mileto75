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
        private readonly IPropertyRepository _propertyRepository;

        public ProductService(IProductRepository productRepository,
            IPropertyRepository propertyRepository)
        {
            _productRepository = productRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<ItemResultModel<Product>> Add(string name, int categoryId, decimal price, IEnumerable<int> properties)
        {
            //perform checks(price for example)
            //get the properties
            var allProperties = await _propertyRepository.GetAllAsync();
            //new product
            var newProduct = new Product
            {
                Name = name,
                Price = price,
                CategoryId = categoryId,
                Properties = allProperties.Where(pr => properties.Contains(pr.Id))
                .ToList()
            };
            //save to the database
            if(!await _productRepository.AddAsync(newProduct))
            {
                return new ItemResultModel<Product> {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>{new ValidationResult("Something went wrong!") }
                };
            }
            //save success!
            return new ItemResultModel<Product> {IsSuccess = true};
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
