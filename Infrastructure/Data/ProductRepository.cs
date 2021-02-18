using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storecontext;
        public ProductRepository(StoreContext storeContext )
        {
            _storecontext = storeContext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _storecontext.products.Include(p=>p.producttype).Include(p=>p.productBrand).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storecontext.products.Include(p=>p.productBrand).Include(p=>p.producttype)
            .ToListAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductbrandsAsync()
        {
            return await _storecontext.productBrands.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductType>> GetProducttypesAsync()
        {
            return await _storecontext.productTypes.ToListAsync();
        }
    }
}