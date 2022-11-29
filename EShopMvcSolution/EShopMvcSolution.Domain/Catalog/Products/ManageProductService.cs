using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.Application.Catalog.Products.Dtos;
using EShopMvcSolution.Application.Dtos;
using EShopMvcSolution.Data.EF;
using EShopMvcSolution.Data.Entity;

namespace EShopMvcSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopMvcDbContext _context;

        public ManageProductService(EShopMvcDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Prince = request.Price
            };   
            _context.Products.Add(product);
            return  await _context.SaveChangesAsync();


        }

        public async Task<int> Delete(Product productId)
        {
            
            _context.Products.Remove(productId);
            return await _context.SaveChangesAsync();
            
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
