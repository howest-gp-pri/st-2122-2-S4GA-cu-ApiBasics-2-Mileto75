using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<ItemResultModel<Product>> GetAllAsync();
        Task<ItemResultModel<Product>> GetByIdAsync(int id);
        Task<ItemResultModel<Product>> Add(string name, int categoryId,
            decimal price, IEnumerable<int> properties);
        Task<ItemResultModel<Product>> UpdateAsync(int id,string name, int categoryId,
            decimal price, IEnumerable<int> properties);
        Task<bool> DeleteAsync(int id);
    }
}
